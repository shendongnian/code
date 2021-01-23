    using (SqlConnection conn = new SqlConnection(connectionStringSQL))
    {
         conn.Open();
         using (SqlCommand command = new SqlCommand("SELECT * FROM Table1"))
         {
                        cmd1 = conn.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = command;
                        cmd1.ExecuteNonQuery();
    
         }
         
    }
