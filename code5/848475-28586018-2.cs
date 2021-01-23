    private static CookieContainer GetAuthCookies(Uri webUri, string userName, string password)
    {
        var securePassword = new SecureString();
        foreach (var c in password) { securePassword.AppendChar(c); }
        var credentials = new SharePointOnlineCredentials(userName, securePassword);
        var authCookie = credentials.GetAuthenticationCookie(webUri);
        var cookieContainer = new CookieContainer();
        cookieContainer.SetCookies(webUri, authCookie);
        return cookieContainer;
    }
