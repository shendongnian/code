       void Notify()
    {
        lock (syncPrimitive)
        {
            Monitor.Pulse(syncPrimitive);
        }
    }
    void RunLoop()
    {
    
        for (;;)
        {
            // do work here...
    
            lock (syncPrimitive)
            {
                Monitor.Wait(syncPrimitive);
            }
        }
    }
