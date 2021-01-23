    public class Link
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string name { get; set; }
        public string render { get; set; }
        public string prompt { get; set; }
    }
    public class Datum
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public class Query
    {
        public string href { get; set; }
        public string rel { get; set; }
        public string name { get; set; }
        public string prompt { get; set; }
        public List<Datum> data { get; set; }
    }
    public class Collection
    {
        public string version { get; set; }
        public string href { get; set; }
        public List<Link> links { get; set; }
        public List<Query> queries { get; set; }
    }
    public class FPResponse
    {
        public Collection collection { get; set; }
    }
