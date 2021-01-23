	class DatabaseInitializer : IDatabaseInitializer<DatabaseContext>
	{
		public void InitializeDatabase(DatabaseContext context)
		{
			// your implementation
		}
	}
	Database.SetInitializer(new DatabaseInitializer());
