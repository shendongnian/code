    public class Doc
    {
        public string enID { get; set; }
        public string startDate { get; set; }
        public string bName { get; set; }
        public string pName { get; set; }
        public List<string> UName { get; set; }
        public List<string> agent { get; set; }
    }
    
    public class Response
    {
        public int numfound { get; set; }
        public int start { get; set; }
        public List<Doc> docs { get; set; }
    }
    
    public class ResponseRoot
    {
        public Response response { get; set; }
    }
