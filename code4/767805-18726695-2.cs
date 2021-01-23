	class OracleApplicationRepository : IApplicationRepository
	{
		public readonly OracleDbConnection _dbConnection;
		
		public OracleApplicationRepository(OracleDbConnection dbConnection)
		{
			_dbConnection = dbConnection;
		}
		IEnumerable<Application> GetAll()
		{
			// up to you, the viewer
			throw new NotImplementedException();
		}
		
		void Update(Application app)
		{
			// up to the viewer
		}
		
		void Delete(Application app)
		{
			// up to the viewer
		}
		
		void Insert(Application app)
		{		
			using (var command = _dbConnection.CreateCommand())
			{
				// or whatever the syntax is
				command.Parameters["AuthKey"] = app.AuthKey;
				
				command.ExecuteNonQuery();
			}
		}
	}
	class OracleUnitOfWork : IUnitOfWork
	{
		private readonly OracleDbConnection _dbConnection;
		public OracleUnitOfWork(string connectionString)
		{
			_dbConnection = new OracleDbConnection(connectionString);
		}
		
		public Application Applications 
		{
			get
			{
				// this could be lazy loaded instead of making new instances all over the place
				return new OracleApplicationRepository(_dbConnection); 
			}
		}
		
		public Dispose()
		{
			// close the connection and any transactions
			_dbConnection.Dispose();
		}
	}
