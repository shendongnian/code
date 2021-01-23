    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DAO;
    namespace daoConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                // This code requires the following COM reference in your project:
                //     Microsoft DAO 3.6 Object Library
                //
                var dbe = new DBEngine();
                Database db = dbe.OpenDatabase(@"C:\Users\Gord\Desktop\speed.mdb");
                Recordset rst = db.OpenRecordset(
                        "SELECT TOP 4001 ID FROM tblBooks ORDER BY ID",
                        RecordsetTypeEnum.dbOpenSnapshot);
                rst.MoveLast();
                int startID = rst.Fields["ID"].Value;
                rst.Close();
                rst = db.OpenRecordset(
                        String.Format(
                            "SELECT TOP 10000 Title FROM tblBooks WHERE ID >= {0} ORDER BY ID", 
                            startID),
                        RecordsetTypeEnum.dbOpenDynaset);
                int i = 1;
                while (!rst.EOF)
                {
                    rst.Edit();
                    rst.Fields["Title"].Value = String.Format("Book {0}", i++);
                    rst.Update();
                    rst.MoveNext();
                }
                rst.Close();
                sw.Stop();
                Console.WriteLine(String.Format("{0:0.0} seconds", sw.ElapsedMilliseconds / 1000.0));
            }
        }
    }
