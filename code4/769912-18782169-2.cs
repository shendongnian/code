    bool operationSucceeded = false;
    try 
    { 
        await DoSomethingAsync(); 
        // in case of an exception, we will not reach this line
        operationSucceeded = true;    
    }
    catch (System.UnauthorizedAccessException)
    { }
    
    if (!operationSucceeded)
    {
        var res = new ResourceLoader();
        var accessDenied = new MessageDialog(
               res.GetString("access_denied_text"), 
               res.GetString("access_denied_title"));
        await accessDenied.ShowAsync();       
    }
