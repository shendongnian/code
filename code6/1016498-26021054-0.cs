	string normalConnectionString = RepositoryDbContext.Database.Connection.ConnectionString;
	var connectionBuilder = new SqlConnectionStringBuilder(normalConnectionString);
	connectionBuilder.ConnectTimeout = 10;
	string testConnectionString = connectionBuilder.ConnectionString;
	using (var testRepositoryDbContext = new RepositoryDbContextType(testConnectionString))
	{
		try
		{
			testRepositoryDbContext.Database.Connection.Open();    
			testRepositoryDbContext.Database.Connection.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}	
