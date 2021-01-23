    void TestDispatcherTimer()
    {
        // need to create and start DispatcherTimer on UI thread, because ...
        DispatcherTimer dt = new DispatcherTimer();
        dt.Interval = TimeSpan.FromMilliseconds(5);
        dt.Tick += dt_Tick;
        dt.Start();
        Task.Run(() =>
        {
            // ... if uncommented, each single line crashes because of wrong thread
            // DispatcherTimer dt = new DispatcherTimer(); 
            // dt.Interval = TimeSpan.FromMilliseconds(5); 
            // dt.Tick += dt_Tick; 
            // dt.Start(); 
        });
    }
    
    void dt_Tick(object sender, object e)
    {
        DateTime now = DateTime.Now;
        int id = Environment.CurrentManagedThreadId; // id will always be the UI thread's id
        System.Diagnostics.Debug.WriteLine("tick on thread " + id + ": " + now.Minute + ":" + now.Second + "." + now.Millisecond);
    }
    
    void TestThreadpoolTimer()
    {
        // it doesn't matter if the ThreadPoolTimer is created on UI thread or any other thread
        ThreadPoolTimer tpt = ThreadPoolTimer.CreatePeriodicTimer(tpt_Tick, TimeSpan.FromMilliseconds(5));
    }
    
    void tpt_Tick(ThreadPoolTimer timer)
    {
        DateTime now = DateTime.Now;
        int id = Environment.CurrentManagedThreadId; // id will change, but never be the UI thread's id
        System.Diagnostics.Debug.WriteLine("tick on thread " + id + ": " + now.Minute + ":" + now.Second + "." + now.Millisecond);
    }
