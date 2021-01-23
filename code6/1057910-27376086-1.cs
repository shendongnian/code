    public static IQueryable<T> WhereLessOld<T>(this IQueryable<T> source, DateTime oldDate)
        where T : IDate
    {
        return source.Where(c => !c.IsDeleted && c.DateChanged > oldDate && c.DateChanged < oldDate);
    }
