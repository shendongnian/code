    public override string GetVaryByCustomString(HttpContext context, string custom)
    {
        if (custom.Equals("cache"))
            return Cache.Version; // something like that
    
        return base.GetVaryByCustomString(context, custom);
    }
