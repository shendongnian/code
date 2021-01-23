    var taskResult = Task.WhenAll(tasks);
    try
    {
    	await taskResult;
    }
    catch (Exception e)
    {
    	if (taskResult.IsCanceled)
    	{
    		// Cancellation is most likely due to a shared cancellation token. Handle as needed, possibly check if ((TaskCanceledException)e).CancellationToken == token etc.		
    	}
    	else if (taskResult.IsFaulted)
    	{
    		// use taskResult.Exception which is an AggregateException - which you can iterate over (it's a tree! .Flatten() might help)
    		// caught exception is only the first observed exception
    	}
    	else
    	{
    		// Well, this should not really happen because it would mean: Exception thrown, not faulted nor cancelled but completed
    	}
    }
