    using (var connection = new MySqlConnection(...))
    {
        using (var command = new MySqlCommand(sql, connection))
        {
            ...
        }
    }
