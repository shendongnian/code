    public class Name
    {
        public int id { get; set; }
        public string name { get; set; }
        public int pID { get; set; }
        public long revisionDate { get; set; }
    }
    
    public class RootObject
    {
        public Name name { get; set; }
    }
