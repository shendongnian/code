    private async void GetToken()
        {
            app.Client.Authenticator = OAuth1Authenticator.ForRequestToken(app.ConsumerKey, app.ConsumerSecret);
            RestRequest request = new RestRequest("OAuthGetRequestToken", Method.POST);
            IRestResponse restResponse = await app.Client.ExecuteTask(request);
            HandleResponse(restResponse);
            GetAccesToken();
        }
        private void HandleResponse(IRestResponse response)
        {
            var Response = response;
            System.Diagnostics.Debug.WriteLine(Response.Content);
            QueryString qs = new QueryString(Response.Content);
            app.OAuthToken = qs["oauth_token"];
            app.OAuthTokenSecret = qs["oauth_token_secret"];
            System.Diagnostics.Debug.WriteLine(app.OAuthToken);
            System.Diagnostics.Debug.WriteLine(app.OAuthTokenSecret);
        }
