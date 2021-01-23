     using (SqlConnection conn = new SqlConnection(connection))
            {
                Server db = new Server(new ServerConnection(conn));
    			string script = File.ReadAllText(scriptPath);
    			db.ConnectionContext.ExecuteNonQuery(script);
                
            }
