	public class MyDbContext : DbContext
	{
		public MyDbContext(DbConnection connection, bool contextOwnsConnection)
			:base(connection, contextOwnsConnection)
		{
				
		}
	}
