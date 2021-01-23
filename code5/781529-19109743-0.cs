    namespace Chat
    {    
        class LoginConnect
        {
            private MySqlConnection _connection = new MySqlConnection();
            private string _server;
            public string _database;
            private string _uid;
            private string _password;
            private StringList _messagelist = new StringList();
            private string _port;
            private DataTable _dataTable;
    
            public LoginConnect()
            {
                Initialize();
            }
            
            public DataTable Data
            { get { return _dataTable; } }
    
            public void Initialize()
            {
                _server = "localhost";
                _port = "3307";
                _database = "testlogin";
                _uid = "root";
                _password = "usbw";
    
                string connectionString = "Server=" + _server + ";" + "Port=" + _port + ";" + "Database=" +
                                   _database + ";" + "Uid=" + _uid + ";" + "Pwd=" + _password + ";";
    
                _connection = new MySqlConnection(connectionString);
            }
    
            public bool OpenConnection()
            {
                try
                {
                    _connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server");
                            break;
    
                        case 1042:
                            MessageBox.Show("Unable to connect to any of the specified MySQL hosts");
                            break;
    
                        case 1045:
                            MessageBox.Show("Invalid username/password");
                            break;
                    }
                    return false;
                }
            }
    
            public void LoginQuery(string username, string password)
            {
                string loginquery = "SELECT * FROM logingegevens WHERE Username='" + username + "'AND Password='" + password + "';";
                try
                {
                     MySqlCommand cmd = new MySqlCommand(loginquery, _connection);
                     MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                     adp.Fill(_dataTable);
                     count = _dataTable.Rows.Count;   
                } 
                catch{}//your handling   
            }
        }
    }
