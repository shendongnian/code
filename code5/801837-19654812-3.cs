    public ICommand DisplayPersonView
    {
        get { return new ActionCommand(action => ViewModel = new PersonViewModel(), 
            canExecute => !IsViewModelOfType<Person>()); }
    }
