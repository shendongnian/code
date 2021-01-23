	try
	{
		await _semaphore.WaitAsync();
	}
	catch
	{
		// handle
	}
	
    try
    {
        // todo
    }
    finally
    {
        _semaphore.Release();
    }
