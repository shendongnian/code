        namespace InstagramLogin.Code
        {
        public class InstagramClient
            {
        
                private const string ApiUriDefault = "https://api.instagram.com/v1/";
                private const string OAuthUriDefault = "https://api.instagram.com/oauth/";
                private const string RealTimeApiDefault = "https://api.instagram.com/v1/subscriptions/";
        
                private const string OAuthAutorizeURLDefault = "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code";
                private const string AuthAccessTokenUrlDefault = "https://api.instagram.com/oauth/access_token";
        
                private const string clientId = "clientid";
                private const string clientSecretId = "clientsecretid";
                private const string redirectUri = "http://localhost/InstagramLogin/InstaAuth.aspx";
                private const string websiteUri = "http://localhost/InstagramLogin/InstaAuth.aspx";
        
                public string ApiUri { get; set; }
                public string OAuthUri { get; set; }
                public string RealTimeApi { get; set; }
        
        
                public string OAuthAutorizeURL { get { return OAuthAutorizeURLDefault; } }
                public string ClientId { get { return clientId; } }
                public string ClientSecret { get { return clientSecretId; } }
                public string RedirectUri { get { return redirectUri; } }
                public string AuthAccessTokenUrl { get { return AuthAccessTokenUrlDefault; } }
    //removed props
        }
        }
