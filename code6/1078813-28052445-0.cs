    public ICommand ExitCommand {get; private set;}
    
    public MyViewModel()
    {
        ExitCommand = new DelegateCommand(ExitApp);
    }
