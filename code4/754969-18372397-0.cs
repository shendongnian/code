    // Binding Command.
    private ICommand _nextStepButtonCommand;
    public ICommand NextStepButtonCommand
    {
        get { return _nextStepButtonCommand?? (_nextStepButtonCommand= new RelayCommand(NextStepButton);}
    }
    
    // Button Action
    public void NextStepButton()
    {
       _stepCounter++;
    }
    
    // Button enabled check,
    public bool NextStepButtonEnabled { get { return _stepCounter == 5 ? false : true; } }
    
    private ICommand _previousStepButtonCommand;
    public ICommand PreviousStepButtonCommand
    {
        get { return _previousStepButtonCommand?? (_previousStepButtonCommand= new RelayCommand(PerviousStepButton);}
    }
    
    public void PerviousStepButton()
    {
       _stepCounter--;
    }
    
    public bool PreviousStepButtonEnabled { get { return _stepCounter == 0 ? false : true; } }
