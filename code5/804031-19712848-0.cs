    public override ICommand Copy
    {
        get { return new ActionCommand(action => ViewModel.Copy.Execute(null), 
    canExecute => ViewModel.Copy != null); }
    }
