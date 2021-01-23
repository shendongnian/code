    if (Monitor.TryEnter(_myLock))
    {
        try
        {
            // Your code
        }
        finally
        {
            Monitor.Exit(_myLock);
        }
    }
    else
    {
        // Do something else
    }
