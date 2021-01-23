    class MySqlDbConnection : IConnection
    {
        private MySql.Data.MySqlClient.MySqlConnection connection;
        public MySqlConnection(MySql.Data.MySqlClient.MySqlConnection connection)
        {
            // Check for null
            this.connection = connection;
        }
 
        #region Implementation of IConnection
        public ConnectionString
        {
            get
            {
                return connection.ConnectionString; // Not sure if this is the right name of property
            }
            set
            {
                connection.ConnectionString = value;
            }
        }
        #endregion
    }
