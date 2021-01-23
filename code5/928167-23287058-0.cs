    using (var conn = new SQLiteConnection(@"Data Source=test.db3"))
    using (var cmd = conn.CreateCommand())
    {
        conn.Open();
        cmd.CommandText = "SELECT * FROM random_table_name";
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string name = reader.GetString(reader.GetOrdinal("name"));
                ...
            }
        }
    }
