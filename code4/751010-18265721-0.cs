      if (atimer != null)
      {
          atimer.Stop();
          atimer.Dispose();
          atimer = null;
      }
      
      atimer = new System.Timers.Timer();
      atimer.Interval = 5000;
      atimer.AutoReset = false;
      if (atimer.Enabled)
      {
          return;
      }
      else
      {
          atimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
          atimer.Enabled = true;
      }
