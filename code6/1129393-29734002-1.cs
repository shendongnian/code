    public class TwitterConnection {
            private string _consumerKey = ConfigurationManager.AppSettings.Get("consumerKey");
            private string _consumerSecret = ConfigurationManager.AppSettings.Get("consumerSecret");
            private string _accessKey = ConfigurationManager.AppSettings.Get("accessToken");
            private string _accessToken = ConfigurationManager.AppSettings.Get("accessTokenSecret");
    
            private IHubContext _context = GlobalHost.ConnectionManager.GetHubContext<TwitterHub>();
    
            public TwitterConnection()
            {
                // Access the filtered stream
    			var filteredStream = Stream.CreateFilteredStream();
    
    			filteredStream.MatchingTweetReceived += (sender, args) => 
    			{ 
    				_context.Clients.All.broadcast(args.Tweet.Text);
    			};
    
    			filteredStream.StartStreamMatchingAllConditions();
               
            }
    }
