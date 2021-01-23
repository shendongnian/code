    private static Mutex mutex = new Mutex();
    
    public void SafeSomethingToDB()
    {
        mutex.WaitOne(); // wait until it is safe to enter the critical section
    
        // Critical section begins here
        DoWorkAndStuff();
    
        mutex.ReleaseMutex(); // indicate the end of the critical section
    }
