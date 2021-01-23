    const int MAX_RETRY = 50;
    const int DELAY_MS = 200;
    bool Success = false;
    int Retry = 0;
    
    // Will return an existing mutex if one with the same name already exists
    Mutex mutex = new Mutex(false, "MutexName"); 
    mutex.WaitOne();
    try
    {
    	while (!Success && Retry < MAX_RETRY)
    	{
    		using (StreamWriter Wr = new StreamWriter(ConfPath))
    		{
    			Wr.WriteLine("My content");
    		}
            Success = true;
    	}
    }
    catch (IOException)
    {
      Thread.Sleep(DELAY_MS);
      Retry++;
    }
    finally
    {
    	mutex.ReleaseMutex();
    }
