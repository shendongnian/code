    public class RestRequestData
    {
        public HttpMethod HttpMethod { get; set; }
        public object ContentData { get; set; }
        public IDictionary Headers { get; set; }
        // whatever else is needed
    }
