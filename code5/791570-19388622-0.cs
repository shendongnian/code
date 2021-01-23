    private void delay()
    {
          _delayTimer = new System.Timers.Timer();
          _delayTimer.Interval = 5000;
          _delayTimer.AutoReset = false; //so that it only calls the method once
          _delayTimer.Elapsed += (s,args) => someMethod();
          _delayTimer.Start();
    }
