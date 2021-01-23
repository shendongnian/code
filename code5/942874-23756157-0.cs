    var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["yourConnectionString"].ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            string dbName = builder.InitialCatalog;
            string dbDataSource = builder.DataSource;
            string userId = builder.UserID;
            string pass = builder.Password;
