    public class Collection1
    {
        public string newPrice { get; set; }
        public string pName { get; set; }
    }
    
    public class Results
    {
        public List<Collection1> collection1 { get; set; }
    }
    
    public class RootObject
    {
        public string name { get; set; }
        public int count { get; set; }
        public int version { get; set; }
        public string lastsuccess { get; set; }
        public Results results { get; set; }
    }
