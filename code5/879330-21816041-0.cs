    public class MyItem 
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string Nullable { get; set; }  // also, consider making this bool
    }
    public class MyItemList : IEnumerable<MyItem>
    {
        private List<MyItem> MyItems = new List<MyItem>();
    
        public IEnumerator<MyItem> GetEnumerator()
        {
            return this.MyItems.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
