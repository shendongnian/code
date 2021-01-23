    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    
    namespace SqlMultipleResultsets
    {
        class Program
        {
            static void Main(string[] args)
            {
            SqlConnectionStringBuilder ConnectionString = new SqlConnectionStringBuilder();
            ConnectionString.DataSource = "SQL06";
            ConnectionString.InitialCatalog = "SuperSweetDB";
    
            //ConnectionString.DataSource = "(localdb)\\Projects";
            //ConnectionString.InitialCatalog = "tempdb";
    
            ConnectionString.IntegratedSecurity = true;
    
            string sqlSelect = @"SELECT [Version] FROM ConfigSystem;" +
                                @"SELECT Version2 FROM ConfigSystem";
    
            // string sqlSelect = @"SELECT [Version] = @@VERSION;"
            //                    + @"SELECT Version2 = @@LANGUAGE;" ;
    
                int recordCount;
    
                using (SqlConnection cnn = new SqlConnection(ConnectionString.ToString()))
                {
                    using (SqlCommand command = new SqlCommand(sqlSelect, cnn))
                    {
                        cnn.Open( );
                        SqlDataReader dr = command.ExecuteReader( );
    
                        recordCount = 0;
                        do
                        {
                            Console.WriteLine("Result set: {0}", ++recordCount);
                            while (dr.Read( ))
                            {
                                Console.WriteLine("Version: {0}", dr[0]);
                            }
                            Console.WriteLine(Environment.NewLine);
                        } 
                        while (dr.NextResult( ));                    
                    }   // END command
                }   // END connection
                Console.Write("Press a key to exit...");
                Console.ReadKey();
            } // END Main
        }
    }
