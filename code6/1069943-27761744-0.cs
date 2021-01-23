    public class Datum
    {
        public string nickname { get; set; }
        public object id { get; set; }
        public int account_id { get; set; }
    }
    public class RootObject
    {
        public string status { get; set; }
        public int count { get; set; }
        public List<Datum> data { get; set; }
    }
