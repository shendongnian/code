    private volatile int sharedState = 0;
    private volatile bool spinLock = false;
    
    private void FirstThread()
    {
        sharedState = 1;
        // ensure lock is released after the shared state write!
        Volatile.Write(ref spinLock, true); 
    }
    
    private void SecondThread()
    {
        SpinWait.SpinUntil(() => spinLock);
        Console.WriteLine(sharedState);
    }
