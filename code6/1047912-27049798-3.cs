    // Sign in the user with this external login provider if the user already has a login
    var user = await UserManager.FindAsync(loginInfo.Login);
    if (user != null)
    {
      AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
      var identity = await user.GenerateUserIdentityAsync(UserManager);
      identity.AddClaim(loginInfo.ExternalIdentity.FindFirst(ClaimTypes.GivenName));
      AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent },
        identity);
      return RedirectToLocal(returnUrl);
    }
