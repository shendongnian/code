    public class Legend
    {
        public string layout { get; set; }
        public bool? floating { get; set; }
        public string backgroundColor { get; set; }
        public string align { get; set; }
        public string verticalAlign { get; set; }
        public int? y { get; set; }
       public int? x { get; set; }
    }
       public class Series
    {
        public List<int> data { get; set; }
    }
    public class XAxis
    {
        public List<string> categories { get; set; }
    }
    public class RootObject
    {
        public List<Legend> legend { get; set; }
        public List<Series> series { get; set; }
        public XAxis xAxis { get; set; }
    }
