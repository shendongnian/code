    var connectionString = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
    using(var connection = new NpgsqlConnection(connectionString))
    {
        // use the connection in some way.
        // presumably executing queries against it.
    }
