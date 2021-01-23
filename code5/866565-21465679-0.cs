    public class PagedList<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
        public PagedList(IEnumerable<T> collection, int totalCount)
        {
            Items = collection;
            TotalCount = totalCount;
        }
    }
