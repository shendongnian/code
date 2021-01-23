    var task = Task.Factory.StartNew(() =>
    {
    	Debug.WriteLine("Hello");
    	throw new InvalidOperationException(); // throw an InvalidOperationException that is handled.
    });
    
    try
    {
    	task.Wait();
    }
    catch (AggregateException ae)
    {
    	ae.Handle((x) =>
    	{
    		if (x is InvalidOperationException) // We know how to handle this exception.
    		{
    			Console.WriteLine("InvalidOperationException error.");
    			return true; // Continue with operation.
    		}
    		return false; // Let anything else stop the application.
    	});
    }
