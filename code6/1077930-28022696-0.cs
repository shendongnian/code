    using(SqlConnection connection = new SqlConnection("connection string"))
    {
     
        connection.Open();
     
        using(SqlCommand cmd = new SqlCommand("your sql command", connection))
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        //do something
                    }
                }
            } 
    
        } 
    
    } 
