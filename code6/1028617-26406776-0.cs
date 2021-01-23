    public void ExecuteSQL(string sqlstring, IEnumerable<SqlParameter> sqlparam)
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(sqlstring, objsqlconn))
        {
            cmd.Parameters.AddRange(sqlparam.ToArray());
            cn.Open();
            cmd.ExecuteNonQuery();
        }
    }
