    static void Main(string[] args)
    {
     var follwerUrls = new StringBuilder();
     var followerNameLocationAndTimeZones = new StringBuilder();
    
     var twitterService = new TwitterService("yourConsumerKey", "yourConsumerSecret");
     twitterService.AuthenticateWith("yourToken", "yourTokenSecret");
    
     var userProfile = twitterService.GetUserProfile(new GetUserProfileOptions { IncludeEntities = true, SkipStatus = false });
    			
     var followerOptions = new ListFollowersOptions 
    						{ 
    							IncludeUserEntities = true, 
    							ScreenName = userProfile.ScreenName, 
    							SkipStatus = false, 
    							UserId = userProfile.Id 
    						};
    
     var usersfollowers = twitterService.ListFollowers(followerOptions);
    
     foreach (var follower in usersfollowers)
     {
    	followerNameLocationAndTimeZones.Append(follower.Name);
    	followerNameLocationAndTimeZones.Append(", ");
    	followerNameLocationAndTimeZones.Append(string.IsNullOrEmpty(follower.Location) ? "LOCATION NOT SPECIFIED" : follower.Location);
    	followerNameLocationAndTimeZones.Append(", ");
    	followerNameLocationAndTimeZones.Append(string.IsNullOrEmpty(follower.TimeZone) ? "TIMEZONE NOT SPECIFIED" : follower.TimeZone);
    	followerNameLocationAndTimeZones.Append('\n');
    
    	follwerUrls.Append(follower.Url ?? "URL NOT SPECIFIED");
    	follwerUrls.Append('\n');
     }
    
     Console.WriteLine(followerNameLocationAndTimeZones.ToString());
     Console.WriteLine(follwerUrls.ToString());
     Console.ReadKey();
    }
