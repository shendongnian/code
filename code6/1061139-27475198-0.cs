    public class HttpTest
    {
        public bool ignoreCertificateErrors { get; set; }
        public List<HttpStatusCode> successHTTPStatusCodes { get; set; }
        public string httpVerb { get; set; }
        public HttpMethod Verb { 
            get return (HttpMethod)httpVerb;
        }
    }
