    public interface INamable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
    public class DataReponse<T> where T : INamable
    {
        public bool Success { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
    }
