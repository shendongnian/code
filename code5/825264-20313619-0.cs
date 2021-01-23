    using (var connection = new new MySqlConnection(ConnectionString))
    {
        using (var command = connection.CreateCommand())
        { 
             command.CommandText = SQL_Query;
             command.ExecuteNonQuery();
        }
    }
