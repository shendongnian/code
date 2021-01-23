    if ( ClaimsPrincipal.Current.Identity.IsAuthenticated ) {
    
        var dcUsername = ClaimsPrincipal.Current.Identity;
    
        var cp = ClaimsPrincipal.Current;
       if (cp.FindFirst(ClaimTypes.GivenName) == null ||   cp.FindFirst(ClaimTypes.Surname) == null ) {
    var de = new DirectoryEntry("WinNT://" + dcUsername);
    // get first name and last name from the directory and set the claim back so that you can access these values from anywhere.
         cp.Add(new Claim(ClaimTypes.GivenName, <dc given name>));
         cp.Add(new Claim(ClaimTypes.Surname, <dc sur name>));
    }
         
    }
