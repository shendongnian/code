    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        MySqlCommand command = new MySqlCommand(queryString, connection);
        command.Connection.Open();
        command.ExecuteNonQuery();
    }
