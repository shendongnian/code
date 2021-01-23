    // Assign this using SynchronizationContext.Current from a call made on the UI thread.
    private static SynchronizationContext uiSynchronizationContext;
    public static bool Delay(Func<bool> condition)
    {
        bool result = false;
        AutoResetEvent e = new AutoResetEvent(false);
    
        Timer t = new Timer(delegate 
        {
            uiSynchronizationContext.Send(s => result = condition());
    
            if (result)
                e.Set(); // wait until control property has needed value
        }, e, 0, 1000);
    
        e.WaitOne();
        t.Dispose();
    
        return result;
    }
