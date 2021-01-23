	public sealed class ClassGlobal
	{
		private static readonly string connectionstring;
		public static SqlConnection sqlConnection
		{ 
		   get 
		   {
			  return new SqlConnection(connectionstring);
		   }
		}
		static ClassGlobal()
		{
		}
		public static void DBInit(string server, string database, string uid, string password)
		{
			connectionstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
		}
	}
