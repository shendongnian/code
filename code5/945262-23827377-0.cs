    abstract class BaseRequest
    {
        public string RequestContent { get; protected set; }
        public string ResponseContent { get; set; }
    }
    class Request<TRequest, TResponse> : BaseRequest
        where TRequest : class
        where TResponse : class
