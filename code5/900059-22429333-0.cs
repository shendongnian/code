        class MySqlConnection
        {
            private static MySqlConnection _Instance;
            public static MySqlConnection Instance()
            {
                return _Instance == null ? _Instance = new MySqlConnection () : _Instance;
            }
        }
