    RelayCommand _myCommand;
    public ICommand MyCommand
    {
    get
    {
        if (_myCommand == null)
        {
            _myCommand = new RelayCommand(DoMyCommand,CanDoMyCommand);
        }
        return _myCommand;
    }
    }
