    if (connectionString.ToLower().StartsWith("metadata="))
    {
    	System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(connectionString);
    	connectionString = efBuilder.ProviderConnectionString;
    }
    
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
    DatabaseServer = builder.DataSource;             //  eg "MikesServer"
    DatabaseName = builder.InitialCatalog;           //  eg "Northwind"
