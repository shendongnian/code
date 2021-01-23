    public class HttpErrorException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        public HttpErrorException(HttpStatusCode code, string message)
            : base(message)
        {
            this.StatusCode = code;
        }
    }
    throw new HttpErrorException(400, "You sent a bad request!");
