    class Database
    {
        private static Database _connection = null;
        public static Database Connection
        {
            get
            {
                if(null == _connection)
                {
                    _connection = new Database();
                }
                return _connection;
            }
        }
    }
