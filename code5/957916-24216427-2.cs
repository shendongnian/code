    Monitor.Enter(someObject);
    try
    {
        // do stuff
    }
    finally
    {
        Monitor.Exit(someObject);
    }
