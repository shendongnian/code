    public IEnumerable<T> getDataSet<T>(string query, MySqlParameterCollection parameters, Func<IDataRecord, T> transform)
    {
        MySqlDataReader dataset = null;
        
        using (var conn = new MySqlConnection(conn_string))
        using (var cmd = new MySqlCommand(query, conn))
        {
            if (parameters != null) cmd.Parameters = parameters;
            conn.Open();
    
            using (var rdr = cmd.ExecuteReader())
            {
               while (rdr.Read())
               {
                   yield return transform(rdr)
               }
            }
        }
    }
