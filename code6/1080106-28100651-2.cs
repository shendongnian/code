    try
    {
        using (new System.Runtime.MemoryFailPoint(20)) // 20 megabytes
        {
            ...
        }
    }
    catch (InsufficientMemoryException)
    {
        ...
    }
