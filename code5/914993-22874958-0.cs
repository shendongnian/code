    public class Topic
    {
        public string value { get; set; }
        public string creator { get; set; }
        public string last_set { get; set; }
    }
    
    public class Purpose
    {
        public string value { get; set; }
        public string creator { get; set; }
        public string last_set { get; set; }
    }
    
    public class Channel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string created { get; set; }
        public string creator { get; set; }
        public bool is_archived { get; set; }
        public bool is_member { get; set; }
        public int num_members { get; set; }
        public bool is_general { get; set; }
        public Topic topic { get; set; }
        public Purpose purpose { get; set; }
    }
    
    public class RootObject
    {
        public bool ok { get; set; }
        public List<Channel> channels { get; set; }
    }
