    private readonly object padlock = new object();
    
    private void SomeMethod()
    {
        if(!Monitor.TryEnter(padlock))
            return;
    
        try
        {
            //Do heavy work
        }
        finally
        {
            Monitor.Exit(padlock);
        }
    }
