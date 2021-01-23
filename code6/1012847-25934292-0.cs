    try
    {
        s.Lock(DbEntity, LockMode.None); // throws
    }
    catch
    {
        s.Lock(DbEntity, LockMode.None); // everything ok
    }
