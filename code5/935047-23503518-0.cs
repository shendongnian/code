    //SqlCommand cmd;       <<-- remove
    //SqlDataReader reader; <<-- remove
    SqlConnection conn;
    
    using (conn = new SqlConnection(connectionString))
    {
        try
        {
            conn.Open();
            // Add the variable declarations here
            SqlCommand cmd = new SqlCommand("SELECT * FROM [table-one]", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                // Get a temporary copy of the data in a data table
                dt.Load(reader);
    
                // Do database things on table-one
            }
        }
        catch (Exception ex)
        {
            // Exception caught
            ThrowException(ex);
        }
        ...
