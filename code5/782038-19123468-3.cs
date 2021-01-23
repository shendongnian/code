    public class Node
    {
        public string date_added { get; set; }
        public string date_modified { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public List<Node> children { get; set; }
    }
    public class Roots
    {
        public Node bookmark_bar { get; set; }
    }
               
    public class RootObj
    {
        public string checksum { get; set; }
        public Roots roots { get; set; }
        public int version { get; set; }
    }
