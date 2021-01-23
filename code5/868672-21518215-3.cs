    public bool OpenDBConnection(string ConnectionString)
    {
        attempt = 0;          
        isCurrentOpen = (dConnection.State == ConnectionState.Open);   
        if(isCurrentOpen == false)
        {
           // If no connectionstring received, get it from the config
           if(ConnectionString == null)
               ConnectionString = cConn.GetConnectionString();    
           // Assign the connectionstring to the connection to be opened
           dConnection.ConnectionString = ConnectionString;
           while (!isCurrentOpen && attempt < MaxRetry)                   
           {
               try
               {
                   dConnection.Open();   
                   ......
     
