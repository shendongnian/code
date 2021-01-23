    public static string MapPath(string path)
    {
        if (HttpContext.Current != null)
            return HttpContext.Current.Server.MapPath(path);
    
        return HostingEnvironment.MapPath(path);
    }
