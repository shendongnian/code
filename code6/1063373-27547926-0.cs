    if(!Monitor.TryEnter(someLock))
    {
       return;
    }
    try
    {
        //Critical region
    }
    finally
    {
        Monitor.Exit(someLock);
    }
