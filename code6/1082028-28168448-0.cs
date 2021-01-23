		public static void ExecuteScript(string scriptContent)
		{
		SqlConnection conn = new SqlConnection(dbConnectionString);
		conn.Open();
		Server sqlServer = new Server(new Microsoft.SqlServer.Management.Common.ServerConnection(conn));
		sqlServer.ConnectionContext.InfoMessage += new SqlInfoMessageEventHandler(ConnectionContext_InfoMessage);
		sqlServer.ConnectionContext.ServerMessage += new Microsoft.SqlServer.Management.Common.ServerMessageEventHandler(ConnectionContext_ServerMessage);
		sqlServer.ConnectionContext.ExecuteNonQuery(scriptContent);
		}
		static void ConnectionContext_ServerMessage(object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
		{
		Console.WriteLine("Method : ConnectionContext_ServerMessage" + System.Environment.NewLine + e.Error.Message + System.Environment.NewLine);
		}
		static void ConnectionContext_InfoMessage(object sender, SqlInfoMessageEventArgs e)
		{                
		Console.WriteLine(System.Environment.NewLine + e.Message + System.Environment.NewLine);
		}
