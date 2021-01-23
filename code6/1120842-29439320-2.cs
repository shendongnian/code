    public class Variant
    {
        public string Name { get; set; }
        public string Found { get; set; }
    }
    public class RootObject
    {
        public Dictionary<string, Variant> stats { get; set; }
        public string response { get; set; }
        public int runtimeMs { get; set; }
    }
