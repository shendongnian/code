    // Create a global lock map for your lock instances.
    public static ConcurrentDictionary<string, object> GlobalLockMap =
        new ConcurrentDictionary<string, object> ();
    // ...
    var oLockInstance = GlobalLockMap.GetOrAdd ( "lock name", x => new object () );
    if (oLockInstance == null)
    {
        // handle error
    }
    lock (oLockInstance)
    {
        // do work
    }
