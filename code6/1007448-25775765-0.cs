    var twitterOauthToken = twitter.Properties ["oauth_token"].ToString ();
    var twitterOauthTokenSecret = twitter.Properties ["oauth_token_secret"].ToString ();
    var twitterOauthConsumerKey = twitter.Properties ["oauth_consumer_key"].ToString ();
    var twitterOauthConsumerSecret = twitter.Properties ["oauth_consumer_secret"].ToString ();
    
    
    var request = new RestRequest("1.1/statuses/user_timeline.json");
    
    var client = new RestClient("https://api.twitter.com")
    	{
    		Authenticator = RestSharp.Authenticators.OAuth1Authenticator.ForProtectedResource(twitterOauthConsumerKey, twitterOauthConsumerSecret, twitterOauthToken, twitterOauthTokenSecret)
    	};
    client.ExecuteAsync (request, response => {
    					Console.WriteLine(response.Content);
    					var rootObject = JsonConvert.DeserializeObject<Floadt.Core.Twitter.RootObject> (response.Content);
    					//((TableSource)table.Source).facebookData = rootObject;
    				});
			
		
