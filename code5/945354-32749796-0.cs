    var stream = Tweetinvi.Stream.CreateTweetStream();
    stream.TweetReceived += (sender, args) =>
    {
             if(args.Tweet.IsRetweet || !args.Tweet.UserMentions.Any((x)=> x.Id == user.Id))
              {
                   return;
              }
           //Code to respond to mention here
    }
