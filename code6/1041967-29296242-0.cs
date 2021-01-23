    _applicationSignInManager.AuthenticationManager.SignOut("ApplicationCookie");
    FormsAuthentication.SignOut(); // doing for good measure (might not need)
	// Sign back in (Does the password sign in etc)
    var resultSignIn = helper.PasswordSignIn(userName: userName, password: password, isPersistent: false, shouldLockout: true);
    // Update the HttpContext with the new user
    HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(userName), new string[] { });
    
