    String completeURL = EscapeUriDataStringRfc3986("http://www.myurl.be/*!(),");
            OAuthBase o = new OAuthBase();
            var normalizedUrl = String.Empty;
            var normalizedParameters = String.Empty;
            var oauth_consumer_key = "MY KEY";
            var oauth_consumer_secret = "MY SECRET";
            var oauth_timestamp = o.GenerateTimeStamp();
            var oauth_nonce = o.GenerateNonce();
            var oauth_signature_method = "HMAC-SHA1";
            var oauth_signature = o.GenerateSignature(new Uri(completeURL), oauth_consumer_key, oauth_consumer_secret, null, null, "GET", oauth_timestamp, oauth_nonce, out normalizedUrl, out normalizedParameters);
            var oauth = "OAuth oauth_consumer_key=\"" + oauth_consumer_key + "\",oauth_nonce=\"" + oauth_nonce + "\",oauth_signature=\"" + Uri.EscapeDataString(oauth_signature) +"\",oauth_signature_method=\"" + oauth_signature_method + "\",oauth_timestamp=\"" + oauth_timestamp + "\",oauth_version=\"1.0\"";
            
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", oauth);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip");
       
                using (HttpResponseMessage response = await (client.GetAsync(completeURL)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        String content = await response.Content.ReadAsStringAsync();
                        //DO SOMETHING WITH CONTENT                 
                    }
                }
            }
