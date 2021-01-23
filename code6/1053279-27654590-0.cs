    private async Task SignInAsync(User user, bool isPersistent)
    {
       AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
       var identity = await user.GenerateUserIdentityAsync(UserManager);
       AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
    }
