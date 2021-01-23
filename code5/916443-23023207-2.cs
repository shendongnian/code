    public class DataItem
    {
        public List<ChildItem> ChildItems { get; set; }
        public List<string> FromOptions { get; set; }
        public List<string> ToOptions { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DataItem()
        {
            ChildItems = new List<ChildItem>();
            FromOptions = Enumerable.Range(0,10).Select(x => x.ToString()).ToList();
            ToOptions = Enumerable.Range(0, 10).Select(x => x.ToString()).ToList();
        }
    }
    public class ChildItem
    {
        public string XXXX { get; set; }
        public string DependeeFrom { get; set; }
        public string DependeeTo { get; set; }
    }
