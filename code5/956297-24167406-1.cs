    System.Web.HttpContext.Current.Cache.Insert("name", new CacheEntry<string>("Marcin"));
    
    var name = (CacheEntry<string>) System.Web.HttpContext.Current.Cache.Get("name");
    if (name != null)
    {
    	Console.WriteLine(name.Value);
    }
