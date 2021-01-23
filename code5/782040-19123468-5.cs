    public class Node
    {
        public DateTime date_added { get; set; }
        public DateTime date_modified { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public List<Node> children { get; set; }
    }
