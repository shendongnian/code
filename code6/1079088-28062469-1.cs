    private MySqlConnection _conn;
    public MySqlConnection conn // Returns the connection itself
            {
                get
                {
                   if(_conn == null)
                     _conn = new MySqlConnection(Services.ServerConnection);
                    return _conn;
                }
            }
