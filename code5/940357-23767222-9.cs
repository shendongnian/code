    private static async Task SearchTweets(AuthenticationResponse twitAuthResponse)
        {
            string srchStr = "tweet";
            var client = new HttpClient();
            var searchUrl = string.Format("https://api.twitter.com/1.1/search/tweets.json?q={0}", srchStr);
            var uri = new Uri(searchUrl);
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", twitAuthResponse.AccessToken));
            HttpResponseMessage response2 = await client.GetAsync(uri);
            string content = await response2.Content.ReadAsStringAsync();
        }
        
        private async void GetAuthenticationToken()
        {
            var client = new HttpClient();
            var uri = new Uri("https://api.twitter.com/oauth2/token");
            var encodedConsumerKey = WebUtility.UrlEncode(TwitterConsumerKey);
            var encodedConsumerSecret = WebUtility.UrlEncode(TwitterConsumerSecret);
            var combinedKeys = String.Format("{0}:{1}", encodedConsumerKey, encodedConsumerSecret);
            var utfBytes = System.Text.Encoding.UTF8.GetBytes(combinedKeys);
            var encodedString = Convert.ToBase64String(utfBytes);
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Basic {0}", encodedString));
            var data = new List<KeyValuePair<string, string>> 
            { 
                new KeyValuePair<string, string>("grant_type", "client_credentials") 
            };
            var postData = new FormUrlEncodedContent(data);
            var response = await client.PostAsync(uri, postData);
            AuthenticationResponse authenticationResponse;
            using (response)
            {
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Did not work!");
                var content = await response.Content.ReadAsStringAsync();
                authenticationResponse = JsonConvert.DeserializeObject<AuthenticationResponse>(content);
                if (authenticationResponse.TokenType != "bearer")
                    throw new Exception("wrong result type");
            }
            await SearchTweets(authenticationResponse);
        }
    }
    class AuthenticationResponse
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
