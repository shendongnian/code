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
                        @"Data Source=C:\__tmp\books.accdb;";
                using (var con = new OleDbConnection())
                {
                    con.ConnectionString = myConnectionString;
                    con.Open();
                    using (var cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = 
                                "ALTER TABLE AvailableBooks " +
                                "DROP CONSTRAINT BookAvailableBooks";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText =
                                "ALTER TABLE AvailableBooks " +
                                "DROP CONSTRAINT LibraryAvailableBooks";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText =
                                "ALTER TABLE Book " +
                                "ALTER COLUMN Book_ID AUTOINCREMENT(100,1)";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText =
                                "ALTER TABLE Library " +
                                "ALTER COLUMN Library_ID AUTOINCREMENT(100,1)";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText =
                                "ALTER TABLE AvailableBooks " +
                                "ADD CONSTRAINT BookAvailableBooks " +
                                    "FOREIGN KEY (Book_ID) REFERENCES Book";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText =
                                "ALTER TABLE AvailableBooks " +
                                "ADD CONSTRAINT LibraryAvailableBooks " +
                                    "FOREIGN KEY (Library_ID) REFERENCES Library";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }
    }
