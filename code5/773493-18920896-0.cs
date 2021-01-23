            var restClient = new RestClient(baseUrl);
            OAuthBase oAuth = new OAuthBase();
            
            string nonce = oAuth.GenerateNonce();
            string timeStamp = oAuth.GenerateTimeStamp();
            string normalizedUrl;
            string normalizedRequestParameters;
            string sig = oAuth.GenerateSignature(new Uri(baseUrl + MethodLocation), consumerKey, consumerSecret, Accesstoken, AccessTokenSecret, "GET", timeStamp, nonce, out normalizedUrl, out normalizedRequestParameters);
           // sig = HttpUtility.UrlEncode(sig);
            var request = new RestRequest(MethodLocation);
            request.Resource = string.Format(MethodLocation);
            request.Method = Method.GET;
           // request.AddParameter("api_key", consumerKey);
            request.AddParameter("oauth_consumer_key", consumerKey);
            request.AddParameter("oauth_token", Accesstoken);
            request.AddParameter("oauth_nonce", nonce);
            request.AddParameter("oauth_timestamp", timeStamp);
            request.AddParameter("oauth_signature_method", "HMAC-SHA1");
            request.AddParameter("oauth_version", "1.0");
            request.AddParameter("oauth_signature", sig);
            restClient.ExecuteAsync(request, response =>
            {
                var r = response;
            });
