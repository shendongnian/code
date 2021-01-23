    //Code to be added in the OnStart method
    			
    protected override void OnStart(string[] args){
    ///Some stuff
        
    RunProgram();
    
    ///////////// Timer initialization
    scheduleTimer = new System.Timers.Timer();
    scheduleTimer.Enabled = true;
    scheduleTimer.Interval = 1000;
    scheduleTimer.AutoReset = true;
    scheduleTimer.Start();
    scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);
