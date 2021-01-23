    public class GenericRow
    {
        public string name { get; set; }
        public string height { get; set; }
        public string color { get; set; }
        public string data { get; set; }
    }
    public class DetailedRow : GenericRow
    {
        public bool sortable { get; set; }
        public string classes { get; set; }
    }
