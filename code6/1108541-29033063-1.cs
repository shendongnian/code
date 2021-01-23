    public static IQueryable GetUserStatus()
    {
        var ctx = new AppEntities();
        var currentPageHits = ctx.Pagehits
            .GroupBy(x => x.UserID)
            .SelectMany(x => x.GroupBy(y => y.TimeStamp).OrderByDescending(g=> g.Key).FirstOrDefault())
            .OrderByDescending(x => x.TimeStamp);
    
        return currentPageHits;
    }
