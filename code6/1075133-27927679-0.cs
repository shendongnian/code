    public class Collection1
    {
        public string price { get; set; }
        public object uri { get; set; }
        public string url { get; set; }
    }
    
    public class Results
    {
        public List<Collection1> collection1 { get; set; }
    }
    
    public class RootObject
    {
        public string name { get; set; }
        public int count { get; set; }
        public string frequency { get; set; }
        public int version { get; set; }
        public bool newdata { get; set; }
        public string lastrunstatus { get; set; }
        public string lastsuccess { get; set; }
        public string thisversionstatus { get; set; }
        public string thisversionrun { get; set; }
        public Results results { get; set; }
    }
