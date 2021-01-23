    public class Event
    {
        public List<Elements> door { get; set; }
        public List<Elements> window { get; set; }
    }
    public sealed class Elements
    {
        public int Id {get; set;}
        public IDictionary<string, string> Values { get; set;}
    }
