    using (var connection = new SQLiteConnection())
    {
        connection.ConnectionString = connectionString;
        using (var command = new SQLiteCommand())
        {
            connection.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    // Do something
                }
            }
        }
    }
