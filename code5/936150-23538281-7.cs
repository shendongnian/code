    OperationResult res = _service.Register(username, password);
    
    if(!res.Success)
    {
        if(res.Errors.Any(x => ErrorCodes.UsernameTaken)
        {
           // show error for taken username
        }
        ...
    }
