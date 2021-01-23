    private DelegateCommand<String> _wydajCommand;
    public ICommand WydajCommand
    {
        get
        {
            if (_wydajCommand == null)
                _wydajCommand = new DelegateCommand<String>(Wydaj);
            return _wydajCommand;
        }
    }
