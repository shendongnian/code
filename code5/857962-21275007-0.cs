    class Repository
	{
		public const string db_file = "tasks.db3";
		public static string db_path = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), db_file);
		public static SqliteConnection GetConnection ()
		{
			bool exists = File.Exists (db_path);
			if (!exists)
				SqliteConnection.CreateFile (db_path);
			var conn = new SqliteConnection ("Data Source=" + db_path);
			if (!exists)
				CreateDatabase (conn);
			return conn;
		}
		public static Person Task { get; set; }
		private static void CreateDatabase (SqliteConnection conn)
		{
			var sql = @"CREATE TABLE PERSON (
		Id INTEGER PRIMARY KEY AUTOINCREMENT, 
		Name VARCHAR(250),
		Description VARCHAR(250),
		Enabled BOOLEAN,
		Timestamp DATETIME
        );";
			conn.Open ();
			using (var cmd = conn.CreateCommand ()) {
				cmd.CommandText = sql;
				cmd.ExecuteNonQuery ();
			}
			conn.Close ();
		}
    }
