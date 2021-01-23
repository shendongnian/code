    public bool DoesObjectExsist(String ID)
            {
             bool result=false;
                try
                {    
                    String connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + dbPath + "'";
                    string mySelectQuery = "SELECT Count(*) FROM Object WHERE ID = ?";
    
                    OleDbConnection myConnection = new OleDbConnection(connectionString);
                    
                    OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
                    command.Parameters.AddWithValue("@id",ID);
                    myConnection.Open();
                    OleDbDataReader myReader = myCommand.ExecuteReader();
                    try
                    {
                       if(reader.HasRows)
                            result=true;
                        
                    }
                    finally
                    {
                        myReader.Close();
                        myConnection.Close();
                    }
                    
                }
                catch (Exception e)
                {
                   //log exception
                }
                return result;
            }
