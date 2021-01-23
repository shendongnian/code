    private ITransaction _transaction;
    
    [SetUp]
    public void StartTransaction()
    {
    	_transaction = _inMemoryDatabase.Session.Transaction
    	_transaction.Begin();
    }
    
    [TearDown]
    public void RollbackTransaction()
    {
    	_transaction.Rollback();
    	_transaction.Dispose();
    }
