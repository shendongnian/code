    public RelayCommand LoginCommand
    {
        get
        {
            return _navigateCommand ?? (_navigateCommand = new RelayCommand(
                () =>
                {
                    if (login != null && login.UserName.Equals("Test"))
                    {
                        _navigationService.Navigate(typeof(MainPage));
                    }
                }));
        }
    }
