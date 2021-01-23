    private DbConnection CreateConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }
    private string CreateConnectionString(string server, string databaseName, string userName, string password)
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = server, // server address
            InitialCatalog = databaseName, // database name
            IntegratedSecurity = false, // server auth(false)/win auth(true)
            MultipleActiveResultSets = false, // activate/deactivate MARS
            PersistSecurityInfo = true, // hide login credentials
            UserID = userName, // user name
            Password = password // password
        };
        return builder.ConnectionString;
    }
