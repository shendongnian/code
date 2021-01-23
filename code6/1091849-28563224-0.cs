    public T Get<T>(Expression<Func<T>> getItemCallbackExpression) where T : class
    {
        var cacheID = _cacheKey.GetCacheKey(getItemCallbackExpression);
        var item = HttpRuntime.Cache.Get(cacheID) as T;
        if (item == null)
        {
            item = getItemCallback.Compile()();
            if (_cachePolicy.RenewLeaseOnAccess)
            {
                HttpContext.Current.Cache.Insert(cacheID, getItemCallback, null, System.Web.Caching.Cache.NoAbsoluteExpiration, _cachePolicy.ExpiresAfter);
            }
            else
            {
                HttpContext.Current.Cache.Insert(cacheID, getItemCallback, null, DateTime.UtcNow + _cachePolicy.ExpiresAfter, System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }
        return item;
    }
