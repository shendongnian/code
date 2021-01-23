    public class DataResponse<T> // <-- here
    {
        public bool Success {get;set;}
        public string ResponseMessage {get;set;}
        public T Data {get;set;}
    }
