    public class VendorViewModel
    {
        ...
        public CustomerViewModel Customer { get; set; }
    }
    public class CustomerViewModel
    {
        public string Title { get; set; }
        public IEnumerable<string> TitleOptions { get; set; }
        ...
    }
