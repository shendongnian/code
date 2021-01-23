    public SqlDataReader ExecuteQuery(String query, params object[] p)
    {
        SqlCommand cmd = new SqlCommand(query, sqlConn);
        for (int i = 0; i < p.Length; i++)
        {
            cmd.Parameters.Add(new SqlParameter("@p"+i, p[i]));
        }
            
        SqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }
