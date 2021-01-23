    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.Odbc;
    namespace odbcTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (OdbcConnection con = new OdbcConnection())
                {
                    //con.ConnectionString =
                    //        @"Driver={SQL Server};" +
                    //        @"Server=(local)\SQLEXPRESS;" +
                    //        @"Database=myDb;" +
                    //        @"Trusted_connection=yes;";
                    con.ConnectionString =
                            @"Driver={Microsoft Access Driver (*.mdb, *.accdb)};" +
                            @"Dbq=C:\__tmp\dateTest.accdb;";
                    con.Open();
                    using (OdbcCommand cmd = new OdbcCommand())
                    {
                        DateTime dtm;
                        var accessTime0 = new DateTime(1899, 12, 30);
                        bool fromAccess = (con.Driver == "ACEODBC.DLL");
                        cmd.Connection=con;
                        if (fromAccess)
                            cmd.CommandText = "SELECT {fn CDbl(accessDate)} FROM Table1 WHERE ID = 1";
                        else
                            cmd.CommandText = "SELECT sqlDate FROM Table1 WHERE ID = 1";
                        OdbcDataReader rdr = cmd.ExecuteReader();
                        rdr.Read();
                        if (fromAccess)
                            dtm = accessTime0.AddSeconds(Convert.ToDouble(rdr[0]) * 86400);
                        else
                            dtm = Convert.ToDateTime(rdr[0]);
                        Console.WriteLine(dtm.ToString());
                        rdr.Close();
                    }
                    con.Close();
                }
                Console.WriteLine();
                Console.WriteLine("Done.");
            }
        }
    }
