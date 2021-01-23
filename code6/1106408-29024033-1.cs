    public class HttpErrorException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }
        private HttpErrorException(HttpStatusCode code, string message)
            : base(message)
        {
            this.StatusCode = code;
        }
        public static HttpErrorException BadRequest(string message)
        {
            return new HttpErrorException(400, message);
        }
        public static HttpErrorException InternalServerError(string message)
        {
            return new HttpErrorException(500, message);
        }
        // etc
    }
    
    throw HttpErrorException.BadRequest("You made a bad request!");
