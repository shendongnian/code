    private void Login(object obj)
    {
        ...
        if (user.Authenticated)
        {
            Container.RegisterInstance("CurrentUser", user); 
        }
        ...
    }
