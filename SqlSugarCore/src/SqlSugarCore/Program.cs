﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using SqlSugarTest.Demos;

namespace SqlSugarTest
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (SqlSugarClient db = new SqlSugarClient("server=.;uid=sa;pwd=sasa;database=SqlSugarTest"))
            {
                var dt = db.GetDataTable("select * from student where id=@id", new { id = 1 });

                //设置执行的DEMO
                string switch_on = "EnumType";

                IDemos demo = null;
                switch (switch_on)
                {
                    //ADO.NET基本功能
                    case "Ado": demo = new Ado(); break;
                    //查询
                    case "Select": demo = new Select(); break;
                    //插入
                    case "Insert": demo = new Insert(); break;
                    //更新
                    case "Update": demo = new Update(); break;
                    //删除
                    case "Delete": demo = new Delete(); break;
                    //事务
                    case "Tran": demo = new Tran(); break;
                    //生成实体
                    case "CreateClass": demo = new CreateClass(); break;
                    //枚举类型的支持
                    case "EnumType": demo = new EnumType(); break;

                    //除了多库并行计算外的所有功能都已经移植成功更多例子请关注我的博客

                }
                //执行DEMO
                demo.Init();

                Console.WriteLine("执行成功请关闭窗口");
                Console.ReadKey();
            }
        }
    }
}
