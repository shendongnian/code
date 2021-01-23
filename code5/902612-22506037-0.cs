    public void AccessTokenGet(string authToken)
            {
                this.Token = authToken;
                string accessTokenUrl = string.Format("{0}?client_id={1}&redirect_uri={2}&client_secret={3}&code={4}",
                ACCESS_TOKEN, this.ConsumerKey, CALLBACK_URL, this.ConsumerSecret, authToken);
    
                string response = WebRequest(Method.GET, accessTokenUrl, String.Empty);
    
                if (response.Length > 0)
                {
                    //Store the returned access_token
                    NameValueCollection qs = HttpUtility.ParseQueryString(response);
    
                    if (qs["access_token"] != null)
                    {
                        this.Token = qs["access_token"];
                    }
                }
            }
