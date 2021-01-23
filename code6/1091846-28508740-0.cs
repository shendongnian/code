                Server server = new Server();
                server.ConnectionContext.ConnectionString = @"ConnectionStringHere";
                server.ConnectionContext.Connect();
    
                var ColumnDictionary = new Dictionary<string, int>();
                using (SqlDataReader lQR = server.ConnectionContext.ExecuteReader("sp_help 'dbo.WhicheverTable'"))
                {
                    lQR.NextResult();
                    while (lQR.Read())
                    {
                        ColumnDictionary.Add((String)lQR.GetValue(0),(Int32)lQR.GetValue(3));
                    }
                
                }
    
    
                //Do anything with the dictionary here
                Console.WriteLine("\n- End!"); Console.ReadKey();
