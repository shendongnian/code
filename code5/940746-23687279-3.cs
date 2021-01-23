    const string username = "username@tenant.onmicrosoft.com";
    const string password = "password";
    const string url = "https://tenant.sharepoint.com/";
    var securedPassword = new SecureString();
    foreach (var c in password.ToCharArray()) securedPassword.AppendChar(c);
    var credentials = new SharePointOnlineCredentials(username, securedPassword);
    
    DownloadFile(url,credentials,"/Shared Documents/Report.xslx");
    
    
    private static void DownloadFile(string webUrl, ICredentials credentials, string fileRelativeUrl)
    {
         using(var client = new WebClient())
         {
            client.Credentials = credentials;
            client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            client.DownloadFile(webUrl, fileRelativeUrl);
         }	
    }
