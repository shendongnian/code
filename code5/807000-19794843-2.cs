	/// <summary>
	/// Using {the default} new TransactionScope Considered Harmful
	/// http://blogs.msdn.com/b/dbrowne/archive/2010/06/03/using-new-transactionscope-considered-harmful.aspx
	/// </summary>
	private static TransactionScope CreateTransactionScope(System.Transactions.IsolationLevel isolationLevel = System.Transactions.IsolationLevel.ReadCommitted)
	{
		var transactionOptions = new TransactionOptions
		{
			IsolationLevel = isolationLevel,
			Timeout = TransactionManager.MaximumTimeout
		};
		return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
	}
