    public class MyArray
    {
        public string ID { get; set; }
        public string Title { get; set; }
    }
    
    public class Response
    {
        public List<MyArray> myArray { get; set; }
        public string total_records { get; set; }
        public string returned_count { get; set; }
        public string returned_records { get; set; }
    }
    
    public class RootObject
    {
        public Response response { get; set; }
    }
