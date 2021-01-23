    var connectionString = ConfigurationManager.ConnectionStrings["yourConnectionString"];
    DbProviderFactory factory = DbProviderFactories.GetFactory(connectionString.ProviderName);
    using (DbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = connectionString.ConnectionString;
        connection.Open();
        using (DbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT x from y";
            using (DbDataReader reader=command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //
                }
            }
        }
