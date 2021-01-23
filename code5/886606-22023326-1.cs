    public void DoLotsOfWork<T>(MyClass<T> item) where T : BaseClass, new()
    {
        // do some work
    
        // no need to know what T is here:
        item.DoWork();
    
        // maybe do some other work.
    }
