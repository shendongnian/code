        string strUserName="abc";
        string strPassword="123";
        SecureString ssPwd = new SecureString();
        strPassword.ToList().ForEach(ssPwd.AppendChar);
        ClientContext context = new ClientContext(siteurl);
        SharePointOnlineCredentials credentials = new SharePointOnlineCredentials(strUserName, ssPwd);
        context.Credentials = credentials;
        // The SharePoint web at the URL.
        Web web = context.Web;
        // We want to retrieve the web's properties.
        context.Load(web);
        // Execute the query to the server.
        context.ExecuteQuery();
