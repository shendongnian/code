     public class Col
        {
            public string id { get; set; }
            public string label { get; set; }
            public string pattern { get; set; }
            public string type { get; set; }
        }
    
        public class C
        {
            public object v { get; set; }
        }
    
        public class Row
        {
            public List<C> c { get; set; }
        }
    
        public class RootObject
        {
            public List<Col> cols { get; set; }
            public List<Row> rows { get; set; }
        }
