    private void delay()
    {
          _delayTimer = new System.Timers.Timer();
          _delayTimer.Interval = 5000;
          //_delayTimer.Enabled = true;
          _delayTimer.Elapsed += _delayTimer_Elapsed;
          _delayTimer.Start();
        }
    }
    private void _delayTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
          someMethod();
    }
