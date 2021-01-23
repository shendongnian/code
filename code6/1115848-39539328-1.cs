    [OutputCache(VaryByHeader = "host", Duration = 600, Location = OutputCacheLocation.Server)]
    public ActionResult TestPage()
    {
        var key = GetCacheKey("TestPage");
        
        HttpContext.Cache[key] = new object();
        Response.AddCacheItemDependency(key);
    
        return Content(DateTime.Now.ToString());
    }
    
    public ActionResult TestClearCache()
    {
        var key = GetCacheKey("TestPage");
        HttpContext.Cache.Remove(key);
        return Content("Cache cleared");
    }
    
    private string GetCacheKey(string page)
    {
        return string.Concat(page, Request.Url.Host.ToLower());
    }
