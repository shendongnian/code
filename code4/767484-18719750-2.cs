    public class Test
    {
        public string text { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
    }
    
    public class RootObject
    {
        public List<Test> Test { get; set; }
        public int ErrorCode { get; set; }
        public int Status { get; set; }
        public string StatusString { get; set; }
        public string Message { get; set; }
    }
