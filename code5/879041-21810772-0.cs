    public class ResponseStatus 
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public List<ResponseError> Errors { get; set; }
    }
