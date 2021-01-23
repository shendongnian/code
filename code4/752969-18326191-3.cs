    class ConnectionStrings
    {
        private static string SERVER_ADDRESS = "127.0.0.1";
        private static string DATABASE = "mydb";
        private static string EscapeConnectionStringValue(string value)
        {
            return value.Replace(";", "\";\"");
        }
        public static string GetConnectionString(string username, string password)
        {
            var escapedUsername = EscapeConnectionStringValue(username);
            var escapedPassword = EscapeConnectionStringValue(password);
            var connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3};", SERVER_ADDRESS, DATABASE, escapedUsername, escapedPassword);
            return connectionString;
        }
    }
