    public ICommand RunFixerCommand {get; private set;}
    
    public AssessmentItem()
    {
       RunFixerCommand = new DelegateCommand((p) => RunFixer());
    }
