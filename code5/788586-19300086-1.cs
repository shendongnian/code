    List<string> result = new List<string>();
    using (conn)
    {
        conn.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while(reader.Read())
            {
                result.Add(Convert.ToString(reader["Health Insurance NO"]));
            }
        }
    }
