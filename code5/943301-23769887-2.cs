        private TimeSpan _runningTime = new TimeSpan();
        private void pause_Click()
        {
         if (!paused) {
           _runningTime = _runningTime.Add(DateTime.Now - startTime);
           cdTimer.Stop();
           paused = true;
         } else {
           startTime = DateTime.Now;
           cdTimer.Start();
           paused = false;
         }
        }
        
        void cdTime_Tick()
        {
        	// ...
            TimeSpan difference = DateTime.Now - startTime;
            difference = difference.Add(_runningTime);
        	TimeSpan countdown = countdownFrom - difference;
        	// ...
        }
