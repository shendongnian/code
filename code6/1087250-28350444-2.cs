    splash.Show();
    // Poll every 100ms. Change as desired.
    System.Timers.Timer timer = new Timer(100) { AutoReset = true };
    timer.Elapsed += (s, e) =>
        {
            if (splash_flag.WaitOne(0)) // Check for signal and return without blocking
            {
                // Use Invoke() so you only deal with the form in the UI thread
                splash.Invoke(new Action(() => { splash.Close(); }));
                timer.Stop();
            }
        }
    timer.Start();
