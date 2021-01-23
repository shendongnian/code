    DispatcherTimer preservedDispatcherTimer;
    var dispatcherTimerStart = new DispatcherTimer();
            if (average >= centerOfPlayingField - marginOfDetection && average <= centerOfPlayingField + marginOfDetection)
            {
                **preservedDispatcherTimer = dispatcherTimerStart;**
                dispatcherTimerStart.Interval = TimeSpan.FromMilliseconds(timeToWait);
                dispatcherTimerStart.Tick += new EventHandler(tick_TimerStart);
                startTime = DateTime.Now;
                dispatcherTimerStart.Start();
            }
            //use preservedDispatcherTimer in else 
            else if(preservedDispatcherTimer!=null)
            {
                preservedDispatcherTimer.Stop();
                preservedDispatcherTimer.Interval = TimeSpan.FromMilliseconds(timeToWait);
            }
