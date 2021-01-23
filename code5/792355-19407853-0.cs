    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.OleDb;
    namespace oleDbTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myConnectionString;
                myConnectionString =
                        @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                        @"Data Source=C:\Users\Public\Database1.accdb;";
                using (var con = new OleDbConnection())
                {
                    con.ConnectionString = myConnectionString;
                    con.Open();
                    using (var cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText =
                            @"INSERT INTO Book (Denomination, Author) VALUES ('Hello', 'World')";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
                Console.WriteLine("Done.");
            }
        }
    }
