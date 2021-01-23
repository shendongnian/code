    int msTimeout;
    bool timeLimitReached = false;
    private void Pump(CancellationToken token)
    {
        DateTime now = DateTime.Now;
        System.Timer t = new System.Timer(100);
        t.Elapsed -= t_Elapsed;
        t.Elapsed += t_Elapsed;
        t.Start();
        while(!timeLimitReached)
        {
            Thread.Sleep(250);
            token.ThrowIfCancellationRequested();
        }
    }
    
    void t_Elapsed(object sender, ElapsedEventArgs e)
    {
        TimeSpan elapsed = DateTime.Now - this.readyUpInitialised;
        if (elapsed > msTimeout)
        {
            timeLimitReached = true;
            t.Stop();
            t.Dispose();
        }
    }
    
