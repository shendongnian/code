    public static ClientContext BuildImpersonatedClientContext(this ClientContext context, string username, string password)
    {
        SecureString secureStrPwd = new SecureString();
        foreach (char x in password)
        {
            secureStrPwd.AppendChar(x);
        }
        SharePointOnlineCredentials credentials = new SharePointOnlineCredentials(username, secureStrPwd);
        context.Credentials = credentials;
        return context;
    }
