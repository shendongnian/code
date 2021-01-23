    private const string CacheKey = "TwitterFeed";
    public Task<IEnumerable<Status>> GetTweetsAsync(int count, bool includeRetweets, bool excludeReplies)
    {
      var context = System.Web.HttpContext.Current;
      return GetTweetDataAsync(context, count, includeRetweets, excludeReplies);
    }
    private Task<IEnumerable<Status>> GetTweetDataAsync(HttpContext context, int count, bool includeRetweets, bool excludeReplies)
    {
      var cache = context.Cache;
      Task<IEnumerable<Status>> data = cache[CacheKey] as Task<IEnumerable<Status>>;
      if (data != null)
        return data;
      data = CallTwitterApiAsync(count, includeRetweets, excludeReplies);
      cache.Insert(CacheKey, data, null, GetTwitterExpiryDate(), TimeSpan.Zero);
      return data;
    }
    private async Task<IEnumerable<Status>> CallTwitterApiAsync(int count, bool includeRetweets, bool excludeReplies)
    {
      ...
    }
