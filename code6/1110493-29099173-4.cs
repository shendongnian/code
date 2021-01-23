    public class Datum
    {
        public string device { get; set; }
        public int sells { get; set; }
    }
    
    public class RootObject
    {
        public string element { get; set; }
        public List<Datum> data { get; set; }
        public string xkey { get; set; }
        public List<string> ykeys { get; set; }
        public List<string> labels { get; set; }
        public double barRatio { get; set; }
        public int xLabelMargin { get; set; }
        public string hideHover { get; set; }
        public List<string> barColors { get; set; }
    }
