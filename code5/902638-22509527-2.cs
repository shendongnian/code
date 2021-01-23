    public class Foo
    {
        public Dictionary<string, List<Bar>> addresses { get; set; }
    }
    public class Bar
    {
        public int version { get; set; }
        public string addr { get; set; }
        [DataMember(Name = "OS-EXT-IPS:type")]
        public string OstType { get; set; }
    }
