	class Program
	{
		private const string DefaultDatabase = @"D:\data\db\employee.fdb";
		static void Main(string[] args)
		{
			string database = args.Length > 0 ? args[0] : DefaultDatabase;
			var test = new TestEmbedded(database);
			test.RunTestQuery();
			Console.ReadLine();
		}
	}
	class TestEmbedded
	{
		private readonly string connectionString;
		public TestEmbedded(string database)
		{
			var connectionStringBuilder = new FbConnectionStringBuilder();
			connectionStringBuilder.Database = database;
			connectionStringBuilder.ServerType = FbServerType.Embedded;
			connectionStringBuilder.UserID = "sysdba";
			connectionString = connectionStringBuilder.ToString();
			Console.WriteLine(connectionString);
		}
		internal void RunTestQuery()
		{
			using (var connection = new FbConnection(connectionString))
			using (var command = new FbCommand("select 'success' from RDB$DATABASE", connection))
			{
				Console.WriteLine("Connecting...");
				if (connection.State == System.Data.ConnectionState.Closed) 
				{ 
					connection.Open(); 
				}
				Console.WriteLine("Executing query");
				using (var reader = command.ExecuteReader())
				{
					if (reader.Read())
					{
						Console.WriteLine(reader.GetString(0));
					}
				}
			}
		}
	}
