    public ICommand AddClientCommand
    {
        get { return new RelayCommand(AddClient, CanAddClient); }
    }
    public bool CanAddClient()
    {
        return newClient != null;
    }
