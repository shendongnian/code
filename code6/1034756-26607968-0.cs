        ...
        var timer = new Timer(Callback);
        timer.Change(100, 100);
    }
    
    private static void Callback(object state)
    {
        bool isElapsed = true;// Add your logic to determine if Timer should be stopped
                
        if (!isElapsed) return;
    
        var timer = state as Timer;
    
        if ( timer != null)
            timer.Change(Timeout.Infinite, Timeout.Infinite);
    }
