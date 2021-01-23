    private ICommand _commandSave;
    public ICommand CommandSave
    {
        get { return _commandSave ?? (_commandSave = new SimpleCommand<object, object>(CanSave, ExecuteSave)); }
    }
    private bool CanSave(object param)
    {
        return !string.IsNullOrEmpty(Name);
    }
    private void ExecuteSave(object param)
    {
    }
