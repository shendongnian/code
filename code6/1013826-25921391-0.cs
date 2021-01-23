    public static string GetPath() 
    {  
        Page page = HttpContext.Current.Handler as Page;
        if (page != null)
            return page.AppRelativeVirtualPath;
        return null;
    }
