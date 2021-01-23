    public static DataTable Select(DbProviderFactory factory, string connString, string query, Dictionary<string, object> Parameters = null)
    {
        DataTable dt = new DataTable();
        //Create Query
        using (DbConnection conn = factory.CreateConnection())
        {
            conn.ConnectionString = connectionString;
            using(DbCommand cmd = conn.CreateCommand())
            using(DbDataAdapter da = factory.CreateDataAdapter())
            {
                 cmd.CommandText = query;
                 da.SelectCommand = cmd;
                 if (Parameters != null)
                 {
                     foreach (KeyValuePair<string, object> kvp in Parameters)
                     {
                         cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
                     }
                 }
                 conn.Open();
                 da.Fill(dt);
                 return dt;
            }
        }        
    }
