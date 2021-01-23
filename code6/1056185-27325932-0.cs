    public class CustomHttpError
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
    }
    public class CustomHttpErrorResponse
    {
        public string Custom { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
    public class CustomHttpErrorService : Service
    {
        public object Any(CustomHttpError request)
        {
            throw new HttpError(request.StatusCode, request.StatusDescription);
        }
    }
