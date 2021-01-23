         public string update(int id, string catagory)
                {
                        //creating database connection
                       using( SqlConnection objConnection = new SqlConnection(strConnection))
                {
                        objConnection.Open();
                        string error = "";
                
                        try
                        {
                            string strCommand = "UPDATE Data SET catagory = @catagory WHERE id = @id ";
                            using( SqlCommand objCommand = new SqlCommand(strCommand, objConnection))
                           {
                            objCommand.Parameters.AddWithValue("@catagory",catagory);
                            objCommand.Parameters.AddWithValue("@id",id);
                            objCommand.ExecuteNonQuery();
                           }
                        }
                        catch(System.Data.SqlClient.SqlException ex)
                        {
                            error = ex.ToString();
                        }
                
                        return error;
                
                    }
                }
        
        
   
