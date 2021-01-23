    public class Child
    {
        public string id { get; set; }
        public string namakategori { get; set; }
        public string parent_id { get; set; }
        public List<Child> children { get; set; } // <-- See this
    }
    public class RootObj
    {
        public List<Child> kategori { set; get; }
    }
