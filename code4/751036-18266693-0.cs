    string connectionString = "YourConnectionString";
    //make a sql connection   
    using (var sqlConnection = new SqlConnection(connectionString))
        {
            var serverConnection = new ServerConnection(sqlConnection);
            var server = new Server(serverConnection);
            server.ConnectionContext.ExecuteNonQuery(textentry); 
        }
