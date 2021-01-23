    public class Info
    {
        public int results { get; set; }
        public int statuscode { get; set; }
    }
    public class IdAndName
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class ResponseContent
    {
        public Info Info { get; set; }
        public List<IdAndName> Data { get; set; }
    }
