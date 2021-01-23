    public static bool Delay(Func<bool> condition)
    {
        bool result = false;
        AutoResetEvent e = new AutoResetEvent(false);
    
        var synchContext = SynchyronizationContext.Current;
    
        Timer t = new Timer(delegate 
        {
            synchContext.Send(s => result = condition());
    
            if (result)
                e.Set(); // wait until control property has needed value
        }, e, 0, 1000);
    
        e.WaitOne();
        t.Dispose();
    
        return result;
    }
