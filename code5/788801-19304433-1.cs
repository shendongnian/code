    public class QuoteResponse
    {
        public Response Response { get; set; }
    }
    public class Response
    {
        public string Id { get; set; }
        public IEnumerable<Quote> Quotes { get; set; }
    }
    // Let's get rid of this class altogether, use IEnumerable<Quote> instead
    public class Quotes
    {
        public Quote[] Quote { get; set; }
    }
    public class Quote
    {
        public string Ask { get; set; }
    }
