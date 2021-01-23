    public IEnumerable<String> GetIDs()
    {
        var result = new List<string>();
        using (var dwConn = new SqlConnection(ConnectionString))
        {
            dwConn.Open();
            SqlCommand cmd = dwConn.CreateCommand();
            cmd.CommandText = "SELECT ID FROM Customer";
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(reader["ID"].ToString());
                }
            }                
        }
        return result;
    }
