    public class Options
    {
        public string strokeColor { get; set; }
        public double strokeOpacity { get; set; }
        public int strokeWeight { get; set; }
        public string fillColor { get; set; }
        public double fillOpacity { get; set; }
        public List<List<double>> paths { get; set; }
    }
    
    public class RootObject
    {
        public Options options { get; set; }
    }
