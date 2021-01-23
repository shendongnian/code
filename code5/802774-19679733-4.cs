    DateTime examStartTime;
    System.Windows.Forms.Timer runTimer;
    TimeSpan totalExamTime = new TimeSpan(1, 30, 0); // Set exam time to 1 hour 30 minutes.
    if (runTimer == null)
        runTimer = new System.Windows.Forms.Timer();
    runTimer.Interval = 200;
    runTimer.Tick -= new EventHandler(runTimerTick);
    runTimer.Tick += new EventHandler(runTimerTick);
    examStartTime = DateTime.Now;
    runTimer.Start();
