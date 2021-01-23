    lock(_conn)
    {
        DataTable dt = new DataTable();
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
        {
            sqlDataAdapter.Fill(dt);
        }
    }
