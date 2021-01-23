    // Perform authentication, usually using some kind of AuthenticationFilter or
    // AuthorizationFilter.
    // After authenticating, and still within the Auth*Filter,
    // I'm going to use a GenericIdentity, but this can be converted to a 
    // ClaimsIdentity if you're using the default Name claim.
    IIdentity identity = new GenericIdentity("myUserName", "myAuthenticationType");
    // Again, you could use a ClaimsPrincipal, the concept, however, is the same.
    IPrincipal principal = new GenericPrincipal(identity, null /* no roles */);
    HttpContext.Current.User = principal;
    Thread.CurrentPrincipal = principal;
