    public class DataResponse<T> // class is parametrized with T
    {
        public bool Success {get;set;}
        public string ResponseMessage {get;set;}
        public T Data {get;set;}
    }
