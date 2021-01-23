    public RelayCommand LoginCommand
    {
        get
        {
            return _navigateCommand ?? (_navigateCommand = new RelayCommand(
                () =>
                {
                    if (_authorizationService.UserAuthorized(login))
                    {
                        _navigationService.Navigate(typeof(MainPage));
                    }
                }));
        }
    }
