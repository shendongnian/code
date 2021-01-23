    public static string GetConStrSQL()
    {
        string connectionString = new System.Data.EntityClient.EntityConnectionStringBuilder
        {
            Metadata = "res://*",
            Provider = "System.Data.SqlClient",
            ProviderConnectionString = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                InitialCatalog = "Name Of The Database",
                DataSource = @"ServerNameHere\SQLEXPRESS",
                IntegratedSecurity = false,
                UserID = "sa",               
                Password = "your_password_here",  
            }.ConnectionString
        }.ConnectionString;
        return connectionString;
    }
