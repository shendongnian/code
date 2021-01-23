    public SelectList GetAsSelectList()
    {
        var b = CacheHelper.GetCacheItem("UserSelectList", UsersDelegate, CacheHelper.SlidingParam, CacheHelper.AbsoluteParam);
        return new SelectList((IEnumerable)b, "Id", "Name");
     }
