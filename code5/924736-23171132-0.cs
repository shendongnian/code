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
                    Task task = new Task(() =>
                    {
                        var mytweet = lastTweet;
                        var tweetText = mytweet.Text;
                        ProcessTweet( tweetText );
                    });
                    task.Start();
                }
            }
        }
    }
