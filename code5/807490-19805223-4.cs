    public class Data
    {
        public Response response { get; set; }
    }
    public class Response
    {
        public int success { get; set; }
        public long current_time { get; set; }
        public IDictionary<int, IDictionary<int, IDictionary<int, Price>>> prices { get; set; }
    }
    public class Price
    {
        public Quote current { get; set; }
        public Quote previous { get; set; }
    }
    public class Quote
    {
        public string currency { get; set; }
        public decimal value { get; set; }
        public decimal value_high { get; set; }
        public long date { get; set; }
    }
