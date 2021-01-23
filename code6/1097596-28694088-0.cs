    public class ConnectionStringProvider
    {
        private static string _connectionString;
        
        public static string ConnectionString
        {
            get 
            { 
                if (_connectionString == null)
                    _connectionString = LoadConnectionString();
                return _connectionString; 
            }
        }
        
        private static void LoadConnectionString()
        {
            //fetch it from somewhere
        }
        
    }
