    public void findAllUser()
    {
        const int ExpectedTime = 30000; // 30,000 milliseconds
        // stopwatch keeps track of elapsed time
        Stopwatch sw = Stopwatch.StartNew();
        // Create a timer that reports progress at 500 ms intervals
        System.Timers.Timer UpdateTimer;
        UpdateTimer = new System.Threading.Timer(
            null,
            {
                var percentComplete = (100 * sw.ElapsedMilliseconds) / ExpectedTime;
                if (percentComplete > 100) percentComplete = 100;
                ReportProgress(percentComplete);
                // Update again in 500 ms if not already at max
                if (percentComplete < 100)
                    UpdateTimer.Change(500, Timeout.Infinite);
            }, 500, Timeout.Infinite);
        items = new List<string>();
        // rest of findAllUser here
        // dispose of the timer.
        UpdateTimer.Dispose();
    }
