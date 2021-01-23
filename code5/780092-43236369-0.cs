    protected override string QueryAccessToken(Uri returnUrl, string authorizationCode)
            {
                WebClient client = new WebClient();
                string content = client.DownloadString(
                    TokenEP
                    + "?client_id=" + this._appId
                    + "&client_secret=" + this._appSecret
                    + "&redirect_uri=" + HttpUtility.UrlEncode(returnUrl.ToString())
                    + "&code=" + authorizationCode
                );
    
                dynamic json = System.Web.Helpers.Json.Decode(content);
                if (json != null)
                {
                    string result = json.access_token;
                    return result;
                }
                return null;
            }
