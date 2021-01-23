    private void SignoutAll()
    {
        foreach (var authenticationManager in MyGlobalObject.Sessions)
        {
            authenticationManager.SignOut();
        }
    }
