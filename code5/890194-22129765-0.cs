    public abstract class Controller 
    {
        // ...
        
        public HttpRequestBase Request
        {
            get { return HttpContext == null ? null : HttpContext.Request; }
        }
        public HttpResponseBase Response
        {
            get { return HttpContext == null ? null : HttpContext.Response; }
        }
        // ...
    }
