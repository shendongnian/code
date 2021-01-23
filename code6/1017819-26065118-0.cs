    public MySqlConnection(string connectionString)
    {
        this.mySqlConnection = new SqlConnection(connectionString);
    
        showConnections(); 
    
    }
       
