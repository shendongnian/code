    bool acquaired = false;
    try
    {
        Monitor.Enter(obj, ref acquired);
        ...
    }
    finally
    {
        if (acquired)
        {
            Monitor.Exit(obj)
        }
    }
