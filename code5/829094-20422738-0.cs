    string username = // get username;
    string password = // get password;
    bool rememberMe = // get remember me setting.
 
    if (YourAuthenticationSystem.Authenticate(username, password))
    {
       FormsAuthentication.SetAuthCookie(username, rememberMe);
    }
