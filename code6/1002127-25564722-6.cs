    using (SqlConnection connection = new SqlConnection("Server=(local);Database=Sample;Trusted_Connection=True;"))
    {
        ServerConnection svrConnection = new ServerConnection(connection);
        Server server = new Server(svrConnection);
        server.ConnectionContext.ExecuteNonQuery(script);
    }
