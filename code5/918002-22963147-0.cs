    using (SqlConnection connection = new SqlConnection(connectionString)) 
    {    
      try    
      {
    
                connection.Open();
                SqlCommand command = new SqlCommand("......", connection);
                command.ExecuteNonQuery();    
       } 
       catch (Exception) 
       { 
          /*Handle error*/ 
       }
    
    }
