    public void RunQuery(string sql, Action<SqlParameterCollection> addParameters)
    {
        using (var cn = new SqlConnection("Connection string here") )
        using (var cmd = new SqlCommand(sql, cn))
        {
            if (addParameters != null) addParameters(cmd.Parameters);
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
