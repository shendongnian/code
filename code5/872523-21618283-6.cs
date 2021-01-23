    using MySql.Data;
    using MySql.Data.MySqlClient;
            
            
    namespace Data
    {
        public class DBConnection
        {
            private DBConnection()
            {
            }
            private string databaseName = string.Empty;
            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }
            public string Password { get; set; }
            private MySqlConnection Connection = null;
            private static DBConnection _instance = null;
            public static DBConnection Instance()
            {
                if (_instance == null)
                    _instance = new DBConnection();
               return _instance;
            }
        
            public bool IsConnect()
            {
                bool result = true;
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        result = false;
                    string connstring = string.Format("Server=localhost; database={0}; UID=UserName; password=your password", databaseName);
                    Connection = new MySqlConnection(connstring);
                    Connection.Open();
                    result = true;
                }
        
                return result;
            }
        
           public  MySqlConnection GetConnection()
           {
               return Connection;
           }
           public void Close()
           {
               Connection.Close();
           }        
        }
    }
