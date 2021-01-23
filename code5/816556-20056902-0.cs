    class Level1
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
    public class RootObject
    {
        public List<Level1> Level1 { get; set; }
        public List<List<>> DataLevel { get; set; }
    }
