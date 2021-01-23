    bool lockTaken = false;
    try
    {
        Monitor.TryEnter(someLock, ref lockTaken);
        if (lockTaken)
        {
            //Critical region
        }
    }
    finally
    {
        if(lockTaken) Monitor.Exit(someLock);
    }
