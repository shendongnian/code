    var dict = JsonConvert.DeserializeObject<Dictionary<string, MyItem>>(json);
    public class MyItem
    {
        public string description { get; set; }
        public int cost { get; set; }
        public string group { get; set; }
        public int WeldAngleDegrees { get; set; }
        public string Unit { get; set; }
        public double Width { get; set; }
        public int thickness { get; set; }
    }
