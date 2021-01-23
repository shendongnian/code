	public static void PerTestSetup()
	{
		_tranactionScope = new TransactionScope();
	}
	public static void PerTestTearDown()
	{
		if (_tranactionScope != null)
		{
			_tranactionScope.Dispose(); // Rollback any changes made in a test.
			_tranactionScope = null;
		}
	}
