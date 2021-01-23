    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }
    public class RootObject
    {
        public Geometry geometry { get; set; }
    }
