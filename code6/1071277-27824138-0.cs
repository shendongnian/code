    public Command RunCommand 
    { 
        get { return new Command(async() => await OnRunCommand()); }
    }    
    
    private bool _isRunning;
    public async Task OnRunCommand() 
    {
        if (_isRunning) return;
        _isRunning = true;
        
        // do stuff
        
        _isRunning = false;
    }
