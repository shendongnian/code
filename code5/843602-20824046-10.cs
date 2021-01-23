    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Reason { get; set; }
        public string ResponseBody { get; set; }
    }
