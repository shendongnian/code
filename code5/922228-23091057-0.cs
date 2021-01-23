          private void InitTimer(){
           System.Timers.Timer timer = new System.Timers.Timer();
           timer.Interval = CalculateInterval();
           timer.Elapsed += new ElapsedEventHandler(onElapsed);
                
                timer.Start();
          }
        private double CalculateInterval()
           {
             TimeSpan sleeptime = default(TimeSpan);           
             sleeptime = TimeSpan.FromMinutes(yourInterval);
             return sleeptime.TotalMilliseconds;
           }
       private void onElapsed(object source, ElapsedEventArgs e)
        {
           //do something
        }
           
       }
