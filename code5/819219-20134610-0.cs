    public class Columns
    {
        [JsonProperty(PropertyName="Place 1")]
        public List<int> Place1;
        [JsonProperty(PropertyName="Place 2")]
        public List<int> Place2;
    }
    public class Rows { }
    public class D
    {
        public string __type;
        public object SessionID;
        public int Code;
        public string Message;
        public Rows Rows;
        public Columns Columns;
        public List<List<string>> Set;
    }
    public class StaffDetail
    {
        public D d { get; set; }
    }
