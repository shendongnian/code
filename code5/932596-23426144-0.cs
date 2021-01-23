     public class RootObject
    {
        public string kind { get; set; }
        public string username { get; set; }
        public int totalResults { get; set; }
        public int startIndex { get; set; }
        public int itemsPerPage { get; set; }
        private List<Item> _items=new List<Item>();
        public List<Item> items
        {
            get { return _items; }
            set { _items = value; }
        }
        
    }
