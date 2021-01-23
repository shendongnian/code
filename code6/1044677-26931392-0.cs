    //Code to be added in the Main method
    			
    RunProgram();
    
    ///////////// Timer initialization
    scheduleTimer = new System.Timers.Timer();
    scheduleTimer.Enabled = true;
    scheduleTimer.Interval = 1000;
    scheduleTimer.AutoReset = true;
    scheduleTimer.Start();
    scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);
