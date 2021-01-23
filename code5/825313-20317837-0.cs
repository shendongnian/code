    // Note: Only change this list on the UI thread!
    Tweets = new ReactiveList<Tweet>();
    // Now, TweetViewModels will "follow around" Tweets as you add and remove items
    TweetViewModels = Tweets.CreateDerivedCollection(
        tweet => new TweetTileViewModel(tweet));
    LoadTweets = new ReactiveCommand();
    var newTweets = LoadTweets.RegisterAsyncTask(async _ => {
        // Loads the latest tweets
        return LoadTweetsAsync();
    });
    newTweets.Subscribe(newTweets => {
        // Add in the new tweets we downloaded. This is guaranteed by
        // ReactiveCommand to be on the UI thread
        Tweets.AddRange(newTweets);
    });
