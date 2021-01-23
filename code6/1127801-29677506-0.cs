    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ListExtensions
    {
        public static PaginatedList<Y> ToMappedPaginatedList<T, Y>(this PaginatedList<T> source, Y destinationPlaceholder)
        {
            var mappedList = new List<Y>();
            Mapper.Map(source, mappedList);
            return new PaginatedList<Y>(mappedList, source.PageIndex, source.PageSize, source.TotalCount);
        }
    }
