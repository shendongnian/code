       var loginTask = securityService.LoginAsync(register.UserName, register.Password, true);
       var objectStore = await ExecuteSimpleQuery(loginTask);
    protected async Task<KeyValuePair<bool, string>> ExecuteSimpleQuery(Task<bool> service)
    {
        //...
        try
        {
            success = await service;
        }
        catch (Exception exception)
        {
            //...
        }
        //...
    }
