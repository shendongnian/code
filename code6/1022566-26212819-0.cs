    public async Task ChangeMyPasswordAsync(string password, string oldPassword)
    {
        var identity = await UserManager.FindAsync((Thread.CurrentPrincipal.Identity as ClaimsIdentity).Name, oldPassword);
        if (identity == null)
            throw new AuthenticationException();
    
        CheckError(await UserManager.ChangePasswordAsync(identity.Id, oldPassword, password));
    }
