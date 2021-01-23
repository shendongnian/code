	var connFactory = new OrmLiteConnectionFactory("ConnectionString", SqliteOrmLiteDialectProvider.Instance)
	using (var db = connFactory.Open())
	using (var tran = db.OpenTransaction()) // or even db.BeginTransaction()
	{
	    // I do lots of boring stuff
	    ...
	    // Somewhere else in the code
	    using (var cmd = db.CreateCommand())
	    {
	        cmd.Transaction = tran; 
	    }
	}    
