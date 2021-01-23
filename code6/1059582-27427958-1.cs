        public static DbProviderFactory Factory
        {
            get
            {
                if (dbProviderFactoryEmployee == null)
                {
                    ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings["DSN"];
                    dbProviderFactoryEmployee = DbProviderFactories.GetFactory(connectionSettings.ProviderName);
                    ConnectionString = connectionSettings.ConnectionString;
                }
                return dbProviderFactoryEmployee;
            }
        }
        private static SqlConnection GetDbConnection()
        {
            SqlConnection dbConnection = new SqlConnection(ConnectionString);
            dbConnection.Open();
            return dbConnection;
        }
