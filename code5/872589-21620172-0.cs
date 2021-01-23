    string scriptToRun = File.ReadAllText("Filepath");
    using (SqlConnection conn = new SqlConnection("Yourconnectionstring"))
    {
         Server server = new Server(new ServerConnection(conn));
         server.ConnectionContext.ExecuteNonQuery(scriptToRun);
    }
