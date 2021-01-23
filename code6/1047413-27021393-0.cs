    var arr = new List<int>();
    using (var md = new Context())
    {
        var conn = md.Database.Connection;
        conn.Open();
        using (IDbCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "select Col1,Col2 from Entities";
                    
            using (var reader = (DbDataReader)cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        arr.Add(reader.GetInt32(i));
                    }
                }
            }
        }
    }
