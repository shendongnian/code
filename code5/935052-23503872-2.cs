    DataTable dt = new DataTable();
    //SqlCommand cmd;
    //SqlDataReader reader;
    //SqlConnection conn;
    
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        SqlCommand cmd;
    
        conn.Open();
    
        cmd = new SqlCommand("SELECT * FROM [table-one]", conn);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                // Get a temporary copy of the data in a data table
                dt.Load(reader);
    
                // Do database things on table-one
            }
        } 
    
        cmd = new SqlCommand("SELECT * FROM [table-two] WHERE UserID = @uID", conn);
        cmd.Parameters.Add(new SqlParameter("uID", User_ID));
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                // Get a temporary copy of the data in a data table
                dt.Load(reader);
    
                // Do database things on table-two
            }
        }
    
    }
