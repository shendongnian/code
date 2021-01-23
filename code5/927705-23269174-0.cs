    using (SqlConnection conn = new SqlConnection(connectionStringSQL))
    {
         conn.Open();
         using (SqlCommand command = new SqlCommand("SELECT * FROM Table1"))
         {
                    
         }
         conn.Close();
    }
