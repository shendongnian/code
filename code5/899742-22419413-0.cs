    try
    {
        configModel = LoginUser(loginId, password);
    }
    catch (...)
    {
        
    }
    
    dispatcher.BeginInvoke(() =>
    {
        this.IsRunning = false;
    });
