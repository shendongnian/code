    var twitter = new LinqToTwitter.TwitterContext(auth);
    var tweets = twitter.Status
                        .Where(t => t.Type == LinqToTwitter.StatusType.User && t.ID == "Microsoft")
                        .OrderByDescending(t => t.CreatedAt)
                        .Take(50);
