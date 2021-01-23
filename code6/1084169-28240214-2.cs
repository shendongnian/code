    var key = ...;
    var lock = new ReaderWriterLockSlim();
    
    lock.EnterWriteLock();
    try
    {
        if (dict.ContainsKey(key))
        {
            // update without closures
            var test = dict[key];
            if (External)
                test.Val += 100;
            else
                test.Val -= 100;
        }
    }
    else
    {
        // insert
        var test = new Test { ...initial state... };
        dict.Add(key, test);
    }
    finally
    {
        lock.ExitWriteLock();
    }
