    static void Main(string[] args)
            {
                Hashtable sqlDatatypeholder = new Hashtable();
                DataTable tempTable = new DataTable();
                //Sql Connection      
                string _mySqlUrl = "connection;";
                string _mySqlQuery = "query";
    
                SqlConnection conn = new SqlConnection(_mySqlUrl);
    
                using (conn)
                {
                    SqlCommand command = new SqlCommand(_mySqlQuery, conn);
                    conn.Open();
    
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable schemaTable = reader.GetSchemaTable(); //stores datatypes from sql
                    tempTable.Load(reader); //stores data rows from sql
                    reader.Close();
    
    
                    if (tempTable != null && tempTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            sqlDatatypeholder.Add(row["ColumnName"], row["DataTypeName"]);
                        }
    
                        foreach (DictionaryEntry a in sqlDatatypeholder) {
                            Console.WriteLine(a.Key + " " + a.Value);
                        }
    
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Connection Open - No rows found.");
                        Console.ReadLine();
                    }
                }
            }
