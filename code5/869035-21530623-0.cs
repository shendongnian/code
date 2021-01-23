    try
    {
        bool result = await c.MyTask(cts.Token);
        return result;
    }
    catch (Exception exception)
    {
    	Console.WriteLine("catch invoker exception=" + exception.GetType());
    	Console.WriteLine("catch invoker=" + Thread.CurrentThread.ManagedThreadId);
        return true;
    }
