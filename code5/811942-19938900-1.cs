    //Ie 8 and lower have an issue with the "Cache-Control no-cache" and "Cache-Control store-cache" headers.
    //The work around is allowing private caching only but immediately expire it.
    if ((Request.Browser.Browser.ToLower() == "ie") && (Request.Browser.MajorVersion < 9))
    {
         context.Response.Cache.SetCacheability(HttpCacheability.Private);
         context.Response.Cache.SetMaxAge(TimeSpan.FromMilliseconds(1));
    }
    else
    {
         context.Response.Cache.SetCacheability(HttpCacheability.NoCache);//IE set to not cache
         context.Response.Cache.SetNoStore();//Firefox/Chrome not to cache
         context.Response.Cache.SetExpires(DateTime.UtcNow); //for safe measure expire it immediately
    }
