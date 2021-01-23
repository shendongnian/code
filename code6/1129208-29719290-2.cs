    public async override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
    {
        var result = await base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        // Check result
        return result;
    }
