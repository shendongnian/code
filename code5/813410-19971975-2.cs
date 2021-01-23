    public void disablebrowserbackbutton()
    {
     HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
     HttpContext.Current.Response.Cache.SetNoServerCaching();
     HttpContext.Current.Response.Cache.SetNoStore();
    }
