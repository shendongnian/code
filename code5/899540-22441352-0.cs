    public class PaymentRateTripRequest
    {   
        public int page { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public string sort { get; set; }
        public string dir { get; set; }
        public FilterField[] filter { get; set; }
    }
    public class FilterField
    {
        public string field { get; set; }
        public Dictionary<string,object> data { get; set; }
    }
