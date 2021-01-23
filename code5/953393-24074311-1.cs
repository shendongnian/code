    private void Connect()
    {
        SqlConnection connection;
        server = Server Name
        database = Database Name
        uid = Username
        password = Password
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            
        connection = new SqlConnection(connectionString);
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
    }
