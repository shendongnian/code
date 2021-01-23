    private static void DisposeCancellationTokenAndTimer(CancellationTokenSource cancellationTokenSource, TimerThread.Timer timeoutTimer)
    {
    	try
    	{
    		cancellationTokenSource.Dispose();
    	}
    	catch (ObjectDisposedException)
    	{
    	}
    	finally
    	{
    		HttpClient.DisposeTimer(timeoutTimer);
    	}
    }
