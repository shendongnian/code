    public ICommand AddClientCommand 
    {
        get
        {
            return new DelegateCommand(AddClient, CanExecuteAddClient);
        }
    }
