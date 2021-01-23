        /// <summary>
        /// RestSharp documentation: https://github.com/restsharp/RestSharp/wiki
        /// </summary>
        public class Etsy_portal
        {
            Uri BASE_URL = new Uri("https://openapi.etsy.com/v2/");
    
            string appKey;
            string sharedSecret;
            RestClient restClient;
    
            private string[] _permissions_array;
            public string Permissions
            {
                get
                {
                    string result = _permissions_array[0];
                    int count = _permissions_array.Count();
    
                    for (int i = 1; i < count; i++)
                    {
                        result += " " + _permissions_array[i];
                    }
    
                    return result;
                }
            }
    
            public Etsy_portal(string appKey_, string sharedSecret_)
            {
                appKey = appKey_;
                sharedSecret = sharedSecret_;
    
                restClient = new RestClient(BASE_URL);
    
                //todo move permissions to Web.config
                _permissions_array = new string[] { "listings_r", "listings_w", "listings_d", "shops_rw" };
            }
    
            public string GetConfirmUrl(out string oauth_token_secret, string callbackUrl_ = null)
            {
                if (callbackUrl_ == null)
                {
                    callbackUrl_ = "oob";
                }
    
                restClient.Authenticator = OAuth1Authenticator.ForRequestToken(appKey, sharedSecret, callbackUrl_);
    
                RestRequest restRequest = new RestRequest("oauth/request_token", Method.POST);
    
                restRequest.AddParameter("scope", Permissions);
                
                IRestResponse response = restClient.Execute(restRequest);
    
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    oauth_token_secret = null;
                    return null;
                }
    
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(response.Content);
    
                oauth_token_secret = queryString["oauth_token_secret"];
                //string oauth_token = queryString["oauth_token"];
                
                return queryString["login_url"];
            }
    
            public void ObtainTokenCredentials(string oauth_token_temp_, string oauth_token_secret_temp_, string oauth_verifier_, out string permanent_oauth_token_, out string permanent_oauth_token_secret_)
            {
                //consumerKey is the appKey you got when you registered your app, same for sharedSecret
                restClient.Authenticator = OAuth1Authenticator.ForAccessToken(appKey, sharedSecret, oauth_token_temp_, oauth_token_secret_temp_, oauth_verifier_);
    
                RestRequest restRequest = new RestRequest("oauth/access_token", Method.GET);
                IRestResponse irestResponse = restClient.Execute(restRequest);
    
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(irestResponse.Content);
    
                permanent_oauth_token_ = queryString["oauth_token"];
                permanent_oauth_token_secret_ = queryString["oauth_token_secret"];
            }
    
            public string GetScopes(string accessToken_, string accessTokenSecret_)
            {
                restClient.Authenticator = OAuth1Authenticator.ForProtectedResource(appKey, sharedSecret, accessToken_, accessTokenSecret_);
    
                RestRequest restRequest = new RestRequest("oauth/scopes", Method.GET);
    
                IRestResponse irestResponse = restClient.Execute(restRequest);
    
                return irestResponse.Content;
            }
        }
