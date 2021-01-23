    // 1. Create the timer
    System.Timers.Timer timer = new System.Timers.Timer();
    timer.AutoReset = false;
    timer.Elapsed += ...;
    // 2. Calculate the number of milliseconds between the scheduled time and the current time
    timer.Interval = (scheduledDate - DateTime.Now).TotalMilliSeconds;
    // 3. Start the timer
    timer.Start();
