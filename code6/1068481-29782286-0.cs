    [HttpPost]
    [Route("current/identity")]
    public async Task<HttpResponseMessage> GetIdentityInfo()
    {
        var currentUser = User as ServiceUser;
        if (currentUser != null)
        {
            var identities = await currentUser.GetIdentitiesAsync();
            var googleCredentials = identities.OfType<GoogleCredentials>().FirstOrDefault();
            if (googleCredentials != null)
            {
                var infos = await GetGoolgeDetails(googleCredentials);
                return Request.CreateResponse(HttpStatusCode.OK, infos);
            }
            var facebookCredentials = identities.OfType<FacebookCredentials>().FirstOrDefault();
            if (facebookCredentials!= null)
            {
                var infos = await GetFacebookDetails(facebookCredentials);
                return Request.CreateResponse(HttpStatusCode.OK, infos);
            }
            var microsoftCredentials = identities.OfType<MicrosoftAccountCredentials>().FirstOrDefault();
            if (microsoftCredentials != null)
            {
                var infos = await GetMicrosoftDetails(microsoftCredentials);
                return Request.CreateResponse(HttpStatusCode.OK, infos);
            }
            var twitterCredentials = identities.OfType<TwitterCredentials>().FirstOrDefault();
            if (twitterCredentials != null)
            {
                var infos = await GetTwitterDetails(currentUser, twitterCredentials);
                return Request.CreateResponse(HttpStatusCode.OK, infos);
            }
        }
        return Request.CreateResponse(HttpStatusCode.OK);
    }
    private async Task<JToken> GetTwitterDetails(ServiceUser currentUser, TwitterCredentials twitterCredentials)
    {
        var twitterId = currentUser.Id.Split(':').Last();
        var accessToken = twitterCredentials.AccessToken;
        string consumerKey = ConfigurationManager.AppSettings["MS_TwitterConsumerKey"];
        string consumerSecret = ConfigurationManager.AppSettings["MS_TwitterConsumerSecret"];
        // Add this setting manually on your Azure Mobile Services Management interface.
        // You will find the secret on your twitter app configuration
        string accessTokenSecret = ConfigurationManager.AppSettings["FG_TwitterAccessTokenSecret"];
        var parameters = new Dictionary<string, string>();
        parameters.Add("user_id", twitterId);
        parameters.Add("oauth_token", accessToken);
        parameters.Add("oauth_consumer_key", consumerKey);
        OAuth1 oauth = new OAuth1();
        string headerString = oauth.GetAuthorizationHeaderString(
            "GET", "https://api.twitter.com/1.1/users/show.json",
            parameters, consumerSecret, accessTokenSecret);
        var infos = await GetProviderInfo("https://api.twitter.com/1.1/users/show.json?user_id=" + twitterId, headerString);
        return infos;
    }
    private async Task<JToken> GetMicrosoftDetails(MicrosoftAccountCredentials microsoftCredentials)
    {
        var accessToken = microsoftCredentials.AccessToken;
        var infos = await GetProviderInfo("https://apis.live.net/v5.0/me/?method=GET&access_token=" + accessToken);
        return infos;
    }
    private async Task<JToken> GetFacebookDetails(FacebookCredentials facebookCredentials)
    {
        var accessToken = facebookCredentials.AccessToken;
        var infos = await GetProviderInfo("https://graph.facebook.com/me?access_token=" + accessToken);
        return infos;
    }
    private async Task<JToken> GetGoolgeDetails(GoogleCredentials googleCredentials)
    {
        var accessToken = googleCredentials.AccessToken;
        var infos = await GetProviderInfo("https://www.googleapis.com/oauth2/v3/userinfo?access_token=" + accessToken);
        return infos;
    }
    private async Task<JToken> GetProviderInfo(string url, string oauth1HeaderString = null)
    {
        using (var client = new HttpClient())
        {
            if (oauth1HeaderString != null)
            {
                client.DefaultRequestHeaders.Authorization = System.Net.Http.Headers.AuthenticationHeaderValue.Parse(oauth1HeaderString); 
            }
            var resp = await client.GetAsync(url).ConfigureAwait(false);
            resp.EnsureSuccessStatusCode();
            string rawInfo = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JToken.Parse(rawInfo);
        }
    }
