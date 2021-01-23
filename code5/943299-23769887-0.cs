    private TimeSpan _runningTime = new TimeSpan();
    private void pause_Click()
    {
    	_runningTime = _runningTime.Add(DateTime.Now - startTime);
    	timer.Stop();
    }
    
    void cdTime_Tick()
    {
    	// ...
    	TimeSpan countdown = countdownFrom - difference;
    	countdown = countdown.Add(_runningTime);
    	// ...
    }
