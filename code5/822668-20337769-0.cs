    public MyDbContext CreateDbContext(string databaseName)
    {
        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString);  // Gets the default connection
        sqlBuilder.InitialCatalog = databaseName;  // Update the database name
        return new MyDbContext(sqlBuilder.ToString());
    }
