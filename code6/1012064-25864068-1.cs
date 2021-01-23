    SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
    connectionString.ConnectionString = @"data source=.;initial catalog=master;";
    connectionString.UserID = "username";
    connectionString.Password = "password";
    using (var sqlConnection = new SqlConnection(connectionString.ConnectionString))
    {
                
    }
