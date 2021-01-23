    public ICommand StartServerCommand
    {
        get
        {
            // If command hasn't been created yet, create it
            if (_startServerCommand == null)
            {
                _startServerCommand = new RelayCommand(
                    param => StartServer()
                );
            }
            return _startServerCommand;
        }
    }
    private void StartServer()
    {
        var ips = GetIpAddresses();
        Response.StartListening(ips);
    }
