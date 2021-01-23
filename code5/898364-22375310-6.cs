    using (SqlConnection con = new SqlConnection(connectionString))
    using (SqlCommand cmd = new SqlCommand(sql, con))
    {
        // add parameters
        con.Open();
        cmd.ExecuteNonQuery();
    }
