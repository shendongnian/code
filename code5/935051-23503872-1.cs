    //SqlCommand cmd;     
    //SqlDataReader reader;  
    //SqlConnection conn;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [table-one]", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())  
            {
               if (reader.HasRows)
               {
                   // Get a temporary copy of the data in a data table
                   dt.Load(reader);
    
                   // Do database things on table-one
               }
            }
        }
        catch (Exception ex)
        {
            // Exception caught
            ThrowException(ex);
        }
    
     ...
