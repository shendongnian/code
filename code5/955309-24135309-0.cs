      var timer = new Timer {AutoReset = true, Interval = 30000}; 1s = 1000ms 
      timer.Elapsed += timer_Elapsed;
      timer.Start();
     .......
     public void timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
     {
          // do stuff here that will execute every 30 seconds
     }
