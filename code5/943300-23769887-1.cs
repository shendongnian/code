    private TimeSpan _runningTime = new TimeSpan();
    private void pause_Click()
    {
    	_runningTime = _runningTime.Add(DateTime.Now - startTime);
    	timer.Stop();
    }
    
    void cdTime_Tick()
    {
    	// ...
        TimeSpan difference = DateTime.Now - startTime;
        difference = difference.Add(_runningTime);
    	TimeSpan countdown = countdownFrom - difference;
    	// ...
    }
