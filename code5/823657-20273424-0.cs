       var timer = new System.Timers.Timer(1000);
       timer.SynchronizationObject = this;
       timer.AutoReset = true; // the event will be fired just once no need to stop the timer. 
       timer.Elapsed += delegate
       {
          // your code
       }
