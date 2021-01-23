    const string username = "username@tenant.onmicrosoft.com";
    const string password = "password";
    const string url = "https://tenant.sharepoint.com/";
    var securedPassword = new SecureString();
    foreach (var c in password.ToCharArray()) securedPassword.AppendChar(c);
    var credentials = new SharePointOnlineCredentials(username, securedPassword);
    
    DownloadFile(url,credentials,"/Shared Documents/Report.xslx");
    
    
    private static void DownloadFile(string webUrl, ICredentials credentials, string fileRelativeUrl)
    {
         var webClient = new WebClient();
         webClient.Credentials = credentials;
         webClient.DownloadFile(webUrl, fileRelativeUrl);	
    }
