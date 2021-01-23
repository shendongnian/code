    public static class PagedList
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, 
            int pageNumber = 0, int pageSize = 5) where T : BaseEntity
        {
            return source.Skip(pageNumber * pageSize).Take(pageSize);
        }
    }
