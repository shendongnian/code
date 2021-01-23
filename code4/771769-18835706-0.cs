    class SomeClass
    {
        public SomeClass()
        {
        }
        private static string serverName = "You server name";
        public static string ServerName
        {
            get
            {
                return serverName;
            }
            set
            {
                serverName = value;
            }
        }
    }
