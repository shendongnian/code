    if (Monitor.TryEnter(Model.lockObject))
    {
        try
        {
            // use object
        }
        finally
        {
            Monitor.Exit(Model.lockObject);
        }
    }
