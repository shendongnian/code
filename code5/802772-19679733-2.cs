    // Set the run timer.
    System.Windows.Forms.Timer runTimer;
    if (runTimer == null)
        runTimer = new System.Windows.Forms.Timer();
    runTimer.Interval = 200;
    runTimer.Tick -= new EventHandler(runTimerTick);
    runTimer.Tick += new EventHandler(runTimerTick);
    RunStartTime = DateTime.Now;
    runTimer.Start();
