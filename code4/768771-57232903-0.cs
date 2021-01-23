    public static DataSet GetDataSetWithParameters(string query, List<SqlParameter> parameters)
    {
        DataSet ds = new DataSet();
        SqlConnection Con = new SqlConnection(ConnectionString);
        Con.Open();
        try
        {
            using (SqlCommand cmd = new SqlCommand(query, Con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                using (SqlDataAdapter Adapter = new SqlDataAdapter(cmd))
                {
                    Adapter.Fill(ds);
                }
                return ds;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection(ref Con);
        }
    }
