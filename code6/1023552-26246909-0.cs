    public static IList<Format> GetFormatAttributes<TViewModel>()
    {
       return typeof(TViewModel)
        .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
        .Select(t => t.GetCustomAttribute<Format>())
        .Where(a != null)
        .ToList();
    }
