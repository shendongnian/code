    public class GenerateMemo
    {
        private MySqlConnection connection;
        private string server, database, uid, password;
        private uint port;
        public GenerateMemo(string _server, uint _port, string _database, string _uid, string _password) //constructor
        {
            server = _server;
            port = _port;
            uid = _uid;
            password = _password;
        }
        private void BuildConnection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            
            builder.Server = server;
            builder.Port = port;
            builder.Database = database;
            builder.UserID = uid;
            builder.Password = password;
            
            connection = new MySqlConnection(builder.ConnectionString);
        }
        public void sqlNonQueryN(string query)
        {
            if (connection == null)
            {
                BuildConnection();
            }
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
