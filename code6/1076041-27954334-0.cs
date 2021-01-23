    public enum ResponseTypes
    {
        Success,
        Failure
    }
    public class Response
    {
        public ResponseTypes ResponseType {get; set;}
        public Exception Error {get;set;}
        public BaseType[] Data {get;set;}
    }
