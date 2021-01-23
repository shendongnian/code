    // In Page_Load
    CacheManager.GetOrAdd(UserID);
    Task<Results> CacheManager.GetOrAdd(int userId)
    {
      lock (locker)
      {
        if (!OurCache.Contains(userId))
        {
          var task = Task.Run(() => ReallyExpensiveMethod(userId));
          OurCache.Add(userId, task);
          return task;
        }
        else
          return OurCache.Get(userId);
      }
    }
    // Usage:
    Results results = CacheManager.GetOrAdd(UserID).Result;
