    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    
    namespace oledbTest1
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var conn = new OleDbConnection())
                {
                    conn.ConnectionString =
                            @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                            @"Data Source=C:\__tmp\testData.accdb;";
                    conn.Open();
                    using (var cmd = new OleDbCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText =
                            "SELECT * FROM Users WHERE ID < 7 ORDER BY UserName";
                        var da = new OleDbDataAdapter(cmd);
                        var dt = new System.Data.DataTable();
                        da.Fill(dt);
                        Console.WriteLine("The initial query from the Access database (WHERE ID < 7) returned:");
                        foreach (System.Data.DataRow dr in dt.Rows)
                        {
                            Console.WriteLine(dr["UserName"]);
                        }
                        System.Data.DataRow[] subsetRows;
                        subsetRows = dt.Select("UserName LIKE 'Gr%'");
                        Console.WriteLine();
                        Console.WriteLine("The equivalent of \".FindFirst UserName LIKE 'Gr%'\" on that subset would be:");
                        Console.WriteLine(subsetRows[0]["UserName"]);
                    }
                    conn.Close();
                }
            }
        }
    }
