    public static IEnumerable Select(this IEnumerable source, string selector,
                                      params object[] values)
    {
        if (source == null) throw new ArgumentNullException("source");
        return source.AsQueryable().Select(selector, values);
    }
