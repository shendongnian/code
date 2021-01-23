    using (var connection = new new MySqlConnection(ConnectionString))
    {
        using (var command = connection.CreateCommand())
        { 
             connection.Open();
             command.CommandText = SQL_Query;
             command.ExecuteNonQuery();
        }
    }
