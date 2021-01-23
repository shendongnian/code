     using (ODBCClass o = new ODBCClass())
    
                {
    
                    OdbcCommand oCommand = o.GetCommand("SELECT * FROM item,inventory");
    
                    OdbcDataReader oReader = oCommand.ExecuteReader();
    
                    while (oReader.Read())
    
                    {
    
                        Console.WriteLine(oReader[0] + " " + oReader[1] + " " + oReader[2] + " " + oReader[3]+ " " + oReader[4]);
    
                    }
    
                    Console.Read();
    
                }
