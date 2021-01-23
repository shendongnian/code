                Tweetinvi.Core.Interfaces.IUser user2 = Tweetinvi.User.GetUserFromScreenName("StackOverflow");
                var userTimelineParam = new Tweetinvi.Core.Parameters.UserTimelineParameters
                {
                    MaximumNumberOfTweetsToRetrieve = 100,
                    IncludeRTS=true 
                }; 
                List<Tweetinvi.Core.Interfaces.ITweet> tweets2= new List<Tweetinvi.Core.Interfaces.ITweet>();
                tweets2 = Timeline.GetUserTimeline(user2, userTimelineParam).ToList();
                foreach (Tweetinvi.Core.Interfaces.ITweet prime2 in tweets2)
                {
                    Debug.WriteLine(prime2.CreatedAt+" "+prime2.Text+" "+prime2.Id.ToString());
                }
