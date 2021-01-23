    var timer = new System.Timers.Timer();
    timer.Interval = 1000; // every second
    timer.Elapsed += TimerTick;
    ...
    private void TimerTick(object state, System.Timers.ElapsedEventArgs e)
    {
        // do some work here
        Thread.Sleep(500);
        var reportProgress = new Action(() => 
        {  
            // inside this anonymous delegate, we can do all the UI updates
            label1.Text += string.Format("Work done {0}\n", DateTime.Now);
        });
        Invoke(reportProgress);
    }
