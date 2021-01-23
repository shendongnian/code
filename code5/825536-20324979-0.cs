    public class ResultSetPager<T>
    {
        public int PageCount { get; set; }
        public IEnumerable<T> SearchResults { get; set; }
    }
    public class Place
    {
        public string SearchVal { get; set; }
        public string Category { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
