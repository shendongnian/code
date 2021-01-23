    public class RootObject
    {
        public Root root { get; set; }
    }
    
    public class Root
    {
        public int id {set;get;}
        public string name {set;get;}
        public Dictionary<string, Container> containers { get; set; }
    }
    public class Container
    {
        public int id {set; get;}
        public string name {set;get;}
        public int value {set;get;}
    }
