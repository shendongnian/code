            OAuth.OAuthBase oauth = new OAuth.OAuthBase();
            string strUrl = "";
            string strParams = "";
            string signature = oauth.GenerateSignature(new Uri(API_URL + "oauth/access_token?oauth_verifier=" + this.oauthVerifier),
                                                this.consumerKey, this.consumerSecret, this.oauthToken, this.requestTokenSecret,
                                                "GET", oauth.GenerateTimeStamp(), oauth.GenerateNonce(),
                                                OAuth.OAuthBase.SignatureTypes.HMACSHA1,
                                                out strUrl, out strParams);
            string authorizationUrl = strUrl + "?" + strParams + "&oauth_signature=" + System.Web.HttpUtility.UrlEncode(signature);
            Debug.WriteLine("url>" + authorizationUrl);
            Response reply = SendGetRequest(authorizationUrl);
            if (reply.Success)
            {
                Debug.WriteLine("access_token>" + reply.Content);
                
