    public class Rates
    {
        
        public double AED { get; set; }
        public double AFN { get; set; }
        public double GBP { get; set; }
    }
    public class RootObject
    {
       
        public string disclaimer { get; set; }
        public string license { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public Rates rates { get; set; }
    }
