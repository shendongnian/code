    public static List<Status> search(string searchTerms, int maxPagination)
    {
        var twitterCtx = new TwitterContext(authorizer);
        List<Status> searchResults = new List<Status>();
        int maxNumberToFind = 100;
        int pagination = 0;
        ulong lastId = 0;
        int count = 0;
                
        do
        {
            var id = lastId;
            var tweets = Enumerable.FirstOrDefault(
                            from tweet in twitterCtx.Search
                            where tweet.Type == SearchType.Search &&
                                tweet.Query == searchTerms &&
                                tweet.Count == maxNumberToFind && (tweet.MaxID == id)
                            select tweet);
                    
            searchResults.AddRange(tweets.Statuses.ToList());
            lastId = tweets.Statuses.Min(x => x.StatusID); // What is the ID of the oldest found (Used to get the next pagination(results)
            pagination++;
    
            count = (pagination > maxPagination) ? 0 : tweets.Count; // Limit amount of search results
        } while (count == maxNumberToFind);
    
        return searchResults;
    }
