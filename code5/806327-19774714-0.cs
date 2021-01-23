    public class SomeResult
    {
        public int total_count { get; set; }
        public List<SomeItem> items { get; set; }
    }
    
    public class SomeItem
    {
        public int total_count { get; set; }
        public DateTime created_at { get; set; }
        ...
    }
