     using TweetSharp;
     // In v1.1, all API calls require authentication
     var service = new TwitterService(_consumerKey, _consumerSecret);
     service.AuthenticateWith(_accessToken, _accessTokenSecret);
     var tweets = service.ListTweetsOnHomeTimeline(
                          new ListTweetsOnHomeTimelineOptions());
     foreach (var tweet in tweets)
     {
         Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
     }
