    using (SqlConnection con = new SqlConnection())
    {
    con.open();
    using (SqlCommand cmd = new SqlCommand(sql, connection))
    {
    
    //object theImg = cmd.ExecuteScalar();
    
    }
    
    con.Dispose();
    }
