    public class Datum
    {
        public string time { get; set; }
        public double value { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
