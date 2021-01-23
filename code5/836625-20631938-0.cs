    // Make sure we have data in the list
    if (listTvShows.Count == 0)
    {
         // No data in the list. Read it from the database
    }
    else
    {
         // Now cache the data
         HttpRuntime.Cache.Insert("TvShows", listTvShows, null, DateTime.Now.AddMinutes(3), System.Web.Caching.Cache.NoSlidingExpiration);
    }
