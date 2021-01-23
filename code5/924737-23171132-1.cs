    // No need to implement INotifyPropertyChanged as there is no listener anymore
    public class Tweet 
    {
        private ITweet lastTweet;
        public ITweet LastTweet
        {
            get { return lastTweet; }
            set
            {
                if (value != lastTweet)
                {
                    lastTweet = value;
                    var actionForTweet = GetActionForTweet(lastTweet);
                    Task task = new Task(() =>
                    {
                        actionForTweet(lastTweet);
                    });
                    task.Start();
                }
            }
        }
        private static Action<ITweet> GetActionForTweet(ITweet tweet)
        {
            // Decide what to do for which kind of tweet
            // In the simplest case this is an if/switch statement
            if ( ... )
                  return x => {
                                  var tweetText = x.Text;
                                  ProcessTweet( tweetText );
                              };
            else 
                  return x => {
                                  // Do something else
                              };
        }
    }
