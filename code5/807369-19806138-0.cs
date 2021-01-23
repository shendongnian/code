    private readonly MvxSubscriptionToken _token;
    public Factory(IMvxMessenger navigator)
    {
        _token = navigator.Subscribe<NavigationMessage>(OnNavigationMessage);
    }
    private void OnNavigationMessage(NavigationMessage navigationMessage)
    {
        switch (navigationMessage.NavType)
        {
             case NavType.One:
                 var newOne = new One(navigationMessage.Args);
                 // use newOne;
                 // ...
             // ...
        }
    }
