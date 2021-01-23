    using (SQLiteConnection connection = new SQLiteConnection(datasource.ConnectionString))
    using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA table_info('myTable');"))
    {
        connection.Open(); //opens connection
        var tableNames = new List<string>();
        using (SQLiteDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                tableNames.Add(reader.GetString(0)); // read 'name' column
            }
        }
        return tableNames;
    }
