    public bool OpenDBConnection(string ConnectionString)
    {
        attempt = 0;          
        if(ConnectionString == null)
            ConnectionString = cConn.SetConnectionString();             
        isCurrentOpen = (dConnection.State == ConnectionState.Open);   
        if (!isCurrentOpen) //to keep up with your logic in case a connection is already opened.
             dConnection = new SqlConnection(ConnectionString); //Initialize Database connection with the Connection String    
         ...
