    public class FL
    {
        public string content { get; set; }
        public string val { get; set; }
    }
    
    public class Row
    {
        public string no { get; set; }
        public List<FL> FL { get; set; }
    }
    
    public class Leads
    {
        public List<Row> row { get; set; }
    }
    
    public class Result
    {
        public Leads Leads { get; set; }
    }
    
    public class Response
    {
        public Result result { get; set; }
        public string uri { get; set; }
    }
    
    public class RootObject
    {
        public Response response { get; set; }
    }
