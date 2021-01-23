    private static SqlDatabaseClient CreateClient(int Id)
    {
        using(MySqlConnection connection = new MySqlConnection(GenerateConnectionString()))
        {
            connection.Open();
            return new SqlDatabaseClient(Id, connection);
        }
    }
