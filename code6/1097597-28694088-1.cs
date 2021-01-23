    public class ConnectionStringProvider
    {
        private static ConnectionStringProvider _instance;
        private string _connectionString;
        
        public static string ConnectionString
        {
            get 
            { 
                if (_instance == null)
                {
                    _instance = new ConnectionStringProvider();
                    _instance.LoadConnectionString();
                }
                
                return _instance._connectionString; 
            }
        }
        
        private void LoadConnectionString()
        {
            //fetch it from somewhere
        }
        
    }
