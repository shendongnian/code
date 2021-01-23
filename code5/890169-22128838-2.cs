    private ICommand _passwordChangedCommand = null;
    public ICommand PasswordChangedCommand
    {
        get
        {
            if (_passwordChangedCommand == null)
            {
                _passwordChangedCommand = new RelayCommand(param => this.PasswordChanged(), null);
            }
            return _passwordChangedCommand;
        }
    }
    private void PasswordChanged()
    {
        // your logic here
    }
