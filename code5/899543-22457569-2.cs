    [Route("/paymentratetrip", "GET"]
    [Filter]
    public class PaymentRateTripRequest : IFilter
    {   
        public int page { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
        public string sort { get; set; }
        public string dir { get; set; }
        public FilterField[] filter { get; set; }
    }
