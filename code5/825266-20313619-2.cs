    using (var connection = new new MySqlConnection(ConnectionString))
    {
        using (var command = connection.CreateCommand())
        { 
             command.CommandText = SQL_Query;
             connection.Open();
             command.ExecuteNonQuery();
        }
    }
