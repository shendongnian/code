    public class Fields
    {
        public string id { get; set; }
    }
    
    public class List
    {
        public Fields fields { get; set; }
    }
    
    public class Paging
    {
        public int pageCurrent { get; set; }
        public int itemMin { get; set; }
        public int itemMax { get; set; }
        public int maxNextPages { get; set; }
        public int pageSize { get; set; }
    }
    
    public class RootObject
    {
        public List<List> list { get; set; }
        public Paging paging { get; set; }
    }
