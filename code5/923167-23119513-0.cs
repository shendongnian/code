    if (HttpContext.Current != null &&
        (HttpContext.Current.Cache[Key] == null || string.IsNullOrEmpty(HttpContext.Current.Cache[Key].ToString()))
    {
         HttpContext.Current.Cache[Key] = data;
    }
         
