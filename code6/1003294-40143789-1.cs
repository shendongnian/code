	public class MyDbContext : DbContext
	{
		public MyDbContext(DbConnection connection, bool contextOwnsConnection)
			:base(connection, contextOwnsConnection)
		{
				
		}
	}
	public class MyDbContextFactory
		: IDbContextFactory<MyDbContext>
	{
		private readonly string _connectionStringName;
		public MyDbContextFactory(string connectionStringName)
		{
			_connectionStringName = connectionStringName;
		}
		public MyDbContext Create()
		{
			var connectionStringSettings = ConfigurationManager.ConnectionStrings[_connectionStringName];
			var connection = DbProviderFactories
				.GetFactory(connectionStringSettings.ProviderName)
				.CreateConnection();
			if (connection == null)
			{
				var message = string.Format(
					"Provider '{0}' could not be used",
					connectionStringSettings.ProviderName);
				throw new NullReferenceException(message);
			}
			connection.ConnectionString = connectionStringSettings.ConnectionString;
			return new MyDbContext(connection, true);
		}
	}
