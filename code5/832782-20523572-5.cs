    // Create a threaded timer
    System.Timers.Timer animationTimer = new System.Timers.Timer();
    animationTimer.Interval = 20;
    animationTimer.AutoReset = false; // Only one Ping! We'll activate it if necessary
    animationTimer.Elapsed += new ElapsedEventHandler(AnimationStep);
    animationTimer.Start();
