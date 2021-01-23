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
    bool CanDoMyCommand(object obj)
        {
            return true;//return true or false accordingly.
        }
        void DoMyCommand(object obj)
        { 
            //Do your work that you want to do on when Command Fires
        }
