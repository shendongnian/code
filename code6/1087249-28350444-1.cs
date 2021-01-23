    splash.Show();
    System.Timers.Timer timer = new Timer(100) { AutoReset = true };
    timer.Elapsed += (s, e) =>
        {
            // Use Invoke() so you only deal with the form in the UI thread
            splash.Invoke(new Action(() =>
            {
                if (splash_flag.WaitOne(1)) // Check for signal and quickly return
                {
                    splash.Close();
                    timer.Stop();
                }
            }
        }
    timer.Start();
