    //you can create your own Identity here.
    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
    //Or add custom claims. Claims Stored in IUserClaimStore are already populated by above creation.
    identity.AddClaim(new Claim("ProfileDATA", "VALUE"));
    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
