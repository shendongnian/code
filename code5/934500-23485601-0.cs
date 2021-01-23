    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        using (var cmd = new SqlCommand(queryString, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
               while (reader.Read())
               {
                  result1 = reader[0];
                  result2 = reader[1];
                  // etc.
               }
            }
        }
    }
