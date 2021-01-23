    public static int GetComponentCount()
    {
        var counter = Sitecore.Context.Items["myCounter"] as int?;
        var count = counter.HasValue ? (int)counter : 0;
        count = count + 1;
        Sitecore.Context.Items["myCounter"] = count;
    
        return count;
    }
