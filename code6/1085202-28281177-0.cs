    static DbConnection CreateDbConnection(
        string providerName, string connectionString)
    {
        // Assume failure.
        DbConnection connection = null;
    
        // Create the DbProviderFactory and DbConnection. 
        if (connectionString != null)
        {
            try
            {
                DbProviderFactory factory =
                    DbProviderFactories.GetFactory(providerName);
    
                connection = factory.CreateConnection();
                connection.ConnectionString = connectionString;
            }
            catch (Exception ex)
            {
                // Set the connection to null if it was created. 
                if (connection != null)
                {
                    connection = null;
                }
                Console.WriteLine(ex.Message);
            }
        }
        // Return the connection. 
        return connection;
    }
