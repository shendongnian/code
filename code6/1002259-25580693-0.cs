    using (var cts = new CancellationTokenSource())
    {
    	try
    	{
    		var cancellationDelayTask = Task.Delay(2000, cts.Token);
    		var taskThatMightThrow = SomethingThatMightThrowAsync(cts.Token);
    		
    		if ((await Task.WhenAny(taskThatMightThrow, cancellationDelayTask)) 
                 == cancellationDelayTask)
    		{
    			// Task.Delay "timeout" finished first.
    		}
    	}
    	catch (OperationCanceledException)
    	{
    		Callback();
    	}
    }
