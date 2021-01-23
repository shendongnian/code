    List<Scope> scopes = new List<Scope>() { Scope.basic };
    InstaConfig config = new InstaConfig("CLIENT_ID", "CLIENT_SECRET", "REDIRECT_URI", scopes);
    
    // use this to redirect user for authenticating your application
    String AuthenticationUriString = config.GetAuthenticationUriString(); 
    
    OAuth oauth = new OAuth(config, "CODE_ATTACHED_WITH_REDIRECTEDURI_AFTERSUCCESSFUL_AUTHENTICATION");
    AuthUser user = oauth.GetAuhtorisedUser();
    
    Console.WriteLine(user.AccessToken);
    Console.WriteLine(user.UserId);
    Console.WriteLine(user.UserName);
    Console.WriteLine(user.FullName);
    Console.WriteLine(user.ProfilePicture);
