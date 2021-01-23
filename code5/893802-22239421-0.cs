    public static IQueryable<T> Enabled<T>(this IQueryable<T> source) 
      where T : class, IUser
    {
        return source.Where(x => x.Enabled);
    }
