    public ICommand CheckCommand
    {
        get
        {
            if(_checkCommand == null)
            {
                _checkCommand = new RelayCommand(param=>
                 {
                    //logic to check the check box
                 });
            }
            return _checkCommand;
        }
    }
