    public class Item
    { 
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Row
    {
        public Item Purchase { get; set; }
        public Item Who { get; set; }
        public Item What { get; set; }
    }
    public class RootObject
    {
        public List<Row> rows { get; set; }
        public bool success { get; set; }
        public int code { get; set; }
    } 
