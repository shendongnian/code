     public class Project
    {
        public string code { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Dictionary<string,Tag> tags { get; set; }
    }
    public class Tag
    {
        public string date { get; set; }
        public string author { get; set; }
    }
