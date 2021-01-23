    using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT 1 FROM Mem_Basic WHERE Id=@id", con))
                    {
          
                        cmd.Parameters.AddWithValue("@ID", yourIDValue);
                        con.Open();
                        var found=(int)cmd.ExecuteScalar(); //1 means found
    
                    }
    
                }
