    public async Task CallingMethod()
    {
        //...
        IdentityResult result = await _repo.RegisterUser(userModel);
        //Do something with the result
        //...
    }
