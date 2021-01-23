	using (var db = new MyContext())
	{
		try
		{
			MyConfiguration.SuspendExecutionStrategy = true;
			db.WriteEvent("My event without retries");
		}
		catch (Exception)
		{
			// ignore any exception if we want to
		}
		finally
		{
			MyConfiguration.SuspendExecutionStrategy = false;
		}
		db.DoAnyOperationWithRetryStrategy();
	}
