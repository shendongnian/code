    using Extentions;
    
    //...
    
    public void SomeMethod()
    {
        var sem = new Semaphore(10, 10);
        sem.Acquire(6);
    }
