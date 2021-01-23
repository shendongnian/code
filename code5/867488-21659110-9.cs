	public static void ExecWithoutRetry(System.Action action)
	{
		var restoreExecutionStrategyState = EbgDbConfiguration.SuspendExecutionStrategy;
		try
		{
			MyConfiguration.SuspendExecutionStrategy = true;
			action();
		}
		catch (Exception)
		{
			// ignore any exception if we want to
		}
		finally
		{
			MyConfiguration.SuspendExecutionStrategy = restoreExecutionStrategyState;
		}
	}
