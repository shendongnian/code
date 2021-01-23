    ConnectionStringSettings c = ConfigurationManager.ConnectionStrings[name];
    DbProviderFactory factory = DbProviderFactories.GetFactory(c.ProviderName);
    using (IDbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = c.ConnectionString; 
        ... etc...
    }
