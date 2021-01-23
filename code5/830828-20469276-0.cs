    public class Result<T>
    {
        public int Total { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public List<T> Items { get; set; }
    }
