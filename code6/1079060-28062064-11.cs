    namespace InstagramLogin.Code
    {
        public class InstagramAuth
        {
            private InstagramClient myApp = new InstagramClient();
     
            public string genUserAutorizationUrl()
            {
                return String.Format(myApp.OAuthAutorizeURL, myApp.ClientId, myApp.RedirectUri);
            }
    
            public AuthUserApiToken getTokenId(string CODE)
            {
                //curl \-F 'client_id=CLIENT-ID' \
                //-F 'client_secret=CLIENT-SECRET' \
                //-F 'grant_type=authorization_code' \
                //-F 'redirect_uri=YOUR-REDIRECT-URI' \
                //-F 'code=CODE' \https://api.instagram.com/oauth/access_token
    
                var wc = new WebClient();
                var wcResponse = wc.UploadValues(myApp.AuthAccessTokenUrl, 
                                    new System.Collections.Specialized.NameValueCollection() { 
                                        { "client_id", myApp.ClientId }, 
                                        { "client_secret", myApp.ClientSecret },
                                        { "grant_type", "authorization_code"},
                                        { "redirect_uri", myApp.RedirectUri},
                                        { "code", CODE}
                                    });
                var decodedResponse = wc.Encoding.GetString(wcResponse);
                AuthUserApiToken UserApiToken = JsonConvert.DeserializeObject<AuthUserApiToken>(decodedResponse);
    
                return UserApiToken;
            }
        }
    }
