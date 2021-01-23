    User user;
    LoginResult loginResult;
    if((loginResult = userService.TryLogin(username, password, out user)) == LoginResult.Successful)
    {
        // do stuff with user
    }
    else 
    {
        // do stuff with loginResult
    }
