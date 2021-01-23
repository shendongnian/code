    using (SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "yoursp";
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
    
            conn.Open();
    
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    
            DataSet ds = new DataSet();
            adapter.Fill(ds);
    
            conn.Close();
        }
    }
