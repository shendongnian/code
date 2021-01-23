    public static List<T> GetViaCache<T>(bool reload, string key, Func<List<T>> loader)
    {
        object list = HttpContext.Current.Cache[key] as List<T>;
        if ((reload) || (list == null))
        {
            list = loader();
            HttpContext.Current.Cache.Insert(key, list, null, DateTime.Now.AddHours(1), TimeSpan.Zero);
        }
        return list;
    }
