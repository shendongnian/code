    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Odbc;
    
    namespace myDbTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                string myConnectionString;
                myConnectionString =
                        @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};" +
                        @"Dbq=C:\Users\Public\Database1.accdb;";
    
                using (var con = new OdbcConnection())
                {
                    con.ConnectionString = myConnectionString;
                    con.Open();
    
                    using (var cmd = new OdbcCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText =
                                @"INSERT INTO Items " +
                                @"SELECT * FROM [Text;FMT=Delimited;HDR=NO;IMEX=2;CharacterSet=437;ACCDB=YES;Database=C:\Users\Public].[Items#csv];";
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
        }
    }
