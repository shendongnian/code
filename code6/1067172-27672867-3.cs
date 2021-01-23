    public IEnumerable<T> getData<T>(string query, List<MySqlParameter> pars, Func<IDataRecord, T> transform)
    {      
        using (var conn = new MySqlConnection(conn_string))
        using (var cmd = new MySqlCommand(query, conn))
        {
            foreach(MySqlParameter p in pars) cmd.Parameters.Add(p);
            conn.Open();
    
            using (var rdr = cmd.ExecuteReader())
            {
               while (rdr.Read())
               {
                   yield return transform(rdr);
               }
            }
        }
    }
