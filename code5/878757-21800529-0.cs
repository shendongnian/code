    object var mylock = new object();
    long isLocked;
    
    public void myFunction()
    {
        if (Monitor.TryEnter(mylock, 0))
        {
            Interlocked.Exchange(ref isLocked, 1);
            try
            {
               // Do work
            }
            finally
            {
                Interlocked.Exchange(ref isLocked, 0);
                Monitor.Exit(mylock);
            }
        }
    }
    
    public bool IsLocked
    {
        get { return Interlocked.Read(ref isLocked)==0; }
    }
