    public class Response
    {
        public bool Success { get; private set; }
        public ExceptionDispatchInfo ErrorInfo { get; private set; }
        public bool HasFailed
        {
            get { return !Success; }
        }
        public static T CreateErrorResponse<T>(ExceptionDispatchInfo errorInfo) where T : Response, new()
        {
            var response = new T();
            response.Success = false;
            response.ErrorInfo = errorInfo;
            return response;
        }
    }
