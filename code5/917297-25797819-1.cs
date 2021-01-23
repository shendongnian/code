    public async Task<TasksService> Prepare()
    {
        GoogleAuthorizationCodeFlow.Initializer initializer = await InitInitializer();
    
        Object credential = new Object();
    
        if (String.IsNullOrEmpty(_username))
        {
            return null;
        }
    
        TasksService service = null;
        try
        {
            credential = await _userCredential.GetCredential(initializer, _username);
        }
        catch (Google.Apis.Auth.OAuth2.Responses.TokenResponseException e)
        {
            service = null;
            return service;
        }
        catch
        {
            return null;
        }
        service = new TasksService(new BaseClientService.Initializer
        {
            HttpClientInitializer = (UserCredential)credential,
            ApplicationName = _applicationName,
        });
        return service;
    } 
