    public class OctopartObject
    {
        public string __class__ { get; set; }
        public int msec { get; set; }
        public Request request { get; set; }
        public List<Result> results { get; set; }
    }
    public class Query
    {
        public string __class__ { get; set; }
        public object brand { get; set; }
        public int limit { get; set; }
        public string mpn { get; set; }
        public object mpn_or_sku { get; set; }
        public string q { get; set; }
        public object reference { get; set; }
        public object seller { get; set; }
        public object sku { get; set; }
        public int start { get; set; }
    }
    public class Request
    {
        public string __class__ { get; set; }
        public bool exact_only { get; set; }
        public List<Query> queries { get; set; }
    }
    public class Brand
    {
        public string __class__ { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }
    public class Manufacturer
    {
        public string __class__ { get; set; }
        public string name { get; set; }
        public string uid { get; set; }
    }
    public class Item
    {
        public string __class__ { get; set; }
        public Brand brand { get; set; }
        public Manufacturer manufacturer { get; set; }
        public string mpn { get; set; }
        public string octopart_url { get; set; }
        public List<object> offers { get; set; }
        public string uid { get; set; }
        public object uid_v2 { get; set; }
    }
    public class Result
    {
        public string __class__ { get; set; }
        public object error { get; set; }
        public int hits { get; set; }
        public List<Item> items { get; set; }
        public object reference { get; set; }
    }
