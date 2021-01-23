        public static DatabaseManager Instance(string connectionStringName)
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null) throw new MissingMemberException("[app.config]", string.Format("ConnectionStrings[{0}]", connectionStringName));
            return new DatabaseManager(connectionStringSettings);
        }
        private DatabaseManager(ConnectionStringSettings connectionInformation)
        {
            _connectionInformation = connectionInformation;
            _parameters = new Dictionary<string, object>();
        }
        private void Initialize()
        {
            _connection = DbProviderFactories.GetFactory(_connectionInformation.ProviderName).CreateConnection();
            _connection.ConnectionString = _connectionInformation.ConnectionString;
            _command = _connection.CreateCommand();
        }
