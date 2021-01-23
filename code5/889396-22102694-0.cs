    public class Author {
        public string Name { get; set; }
        public IList<int> Ref { get; set; } 
    }
    public class Ref {
        public int ID { get; set; }
        public string Location { get; set; }
    }
    public class Result {
        public string Name { get; set; }
        public IList<string> Locations { get; set; } 
    }
