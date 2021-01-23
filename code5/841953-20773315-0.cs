    public class FqlResultSet
    {
        public int subscriber_count { get; set; }
        public int? like_count { get; set; }
    }
    
    public class Datum
    {
        public string name { get; set; }
        public List<FqlResultSet> fql_result_set { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
