    public class Usercontribs
        {
            public string ucstart { get; set; }
        }
    
        public class Querycontinue
        {
            public Usercontribs usercontribs { get; set; }
        }
    
        public class Usercontrib
        {
            public string userid { get; set; }
            public string user { get; set; }
            public int pageid { get; set; }
            public int revid { get; set; }
            public int parentid { get; set; }
            public int ns { get; set; }
            public string title { get; set; }
            public string timestamp { get; set; }
            public string comment { get; set; }
            public int size { get; set; }
        }
    
        public class Query
        {
            public List<Usercontrib> usercontribs { get; set; }
        }
    
        public class RootObject
        {
            public Querycontinue querycontinue { get; set; }
            public Query query { get; set; }
        }
