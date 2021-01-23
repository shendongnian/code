    public static class Session
    {
        static MySqlConnection _connection;
        public static MySqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    // instantiate _connection here
                }
                return _connection;
            }
        }
    }
