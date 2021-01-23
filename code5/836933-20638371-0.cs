    public static class PagingExtensions
    {
        public static PagedList<T> Paginate<T>(this IQueryable<T> source,
                                               int pageIndex, int pageSize)
        {
            return new PagedList<T>(source, pageIndex, pageSize);
        }
    }
