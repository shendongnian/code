    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }
    
    public class Properties
    {
        public string name { get; set; }
        public string iso_3_code { get; set; }
        public string iso_2_code { get; set; }
        public int area { get; set; }
        public string name_1 { get; set; }
        public string gmi_cntry { get; set; }
        public string region { get; set; }
        public int pop2005 { get; set; }
        public string name_12 { get; set; }
    }
    
    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public Geometry geometry { get; set; }
        public string geometry_name { get; set; }
        public Properties properties { get; set; }
    }
    
    public class RootObject
    {
        public string type { get; set; }
        public int totalFeatures { get; set; }
        public List<Feature> features { get; set; }
    } 
