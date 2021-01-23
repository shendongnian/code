    public class ZipCode
    {
        public string zip_code { get; set; }
        public double distance { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
    public class RootObject
    {
        public List<ZipCode> zip_codes { get; set; }
    }
