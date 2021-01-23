    public ICommand Copy
    {
        get { return new ActionCommand(action => childViewModel.Copy.Execute(action), 
    canExecute => childViewModel.Copy.Execute(canExecute)); }
    }
