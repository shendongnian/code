    Stopwatch _buttonHoldStopWatch;
    public DelegateCommand DownCmd { get; set; }
    public DelegateCommand UpCmd { get; set; }
    
    // Delegate commands are from the Prism framework but you can switch these out to 
    regular ICommands
    ResetValueDownCmd = new DelegateCommand(Down);
    ResetValueUpCmd = new DelegateCommand(Up);
    
    // User pressed down
    private void Down(object dayObject)
    {
        _buttonHoldStopWatch.Start(); // start watch
    }
    
    // User left go of press
    private void Up(object dayObject)
    {
        // Did the user hold down the button for 0.5 sec
    	if (_buttonHoldStopWatch.ElapsedMilliseconds >= 500)
        {
    	    // Do something
    	}
    
        _buttonHoldStopWatch.Stop(); // stop watch
    	_buttonHoldStopWatch.Reset(); // reset elapsed time
    }
