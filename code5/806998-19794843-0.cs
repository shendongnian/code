	private static string connString = "the connection string";
	[MTAThread]
	private static void Main(string[] args)
		// Start() is supposed to be called exactly once, during app startup
		// and Stop() exactly once during app shutdown:
		SqlDependency.Start(connString);
		AppDomain.CurrentDomain.ProcessExit += delegate
		{
			SqlDependency.Stop(connString);
		};
		while(true) // to infinity, and beyond.
		{
			using (var context = new LinqDataContext(connString))
			{
				var conn = context.Connection;
				// Connection pooling leaks isolation level changes across 
				// Close()/Open() boundaries, use TransactionScope to avoid this.
				using (var scope = CreateTransactionScope(TransactionScopeOption.Required, transactionOptions))
				{
					conn.Open();
					const string sqlCommand = "UPDATE TOP(1) [Table] SET [Status] = 'budy' OUTPUT INSERTED.[Column], */... MORE ...*/ WHERE [Status] = 'ready'";
					results = conn.Query(sqlCommand);
					scope.Complete();
				}
				DoAwesomeStuffWithTheResults(results, context);
			}
			WaitForWork();
		}
	}
    
