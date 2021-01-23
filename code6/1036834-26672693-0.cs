    public class _BrowseViewModel
    {
        public IEnumerable<_BrowseProduct> BrowseProduct { get; set; }
    }
    public class _BrowseProduct
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        ... etc
    }
