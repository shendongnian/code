    using (SqlConnection conn = new SqlConnection(targetConnexion))
        {
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(File.ReadAllText(createDbScript));
        }
