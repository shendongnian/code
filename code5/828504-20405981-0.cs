    private CancellationTokenSource ts = new CancellationTokenSource();
    
    public void Start()
    {
        System.Timers.Timer t = new System.Timers.Timer();
        t.Interval = 200;
        t.Elapsed += (s, e) =>
        {
            if (ts.Token.IsCancellationRequested)
            {
                // another thread decided to cancel
                Debug.WriteLine("task canceled");
                t.Stop();
            }
        }
        t.Start();
    }
    
    public void Stop()
    {
        // Can't wait anymore => cancel this task 
        ts.Cancel();
    }
