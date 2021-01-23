        private static WebClient GetClient(Uri webUri, string userName, string password)
        {
            var client = new WebClient();
            client.Credentials = GetCredentials(webUri, userName, password);
            client.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
            return client;
        }
        private static SharePointOnlineCredentials GetCredentials(Uri webUri, string userName, string password)
        {
            var securePassword = new SecureString();
            foreach (var ch in password) securePassword.AppendChar(ch);
            return new SharePointOnlineCredentials(userName, securePassword);
        }
 
