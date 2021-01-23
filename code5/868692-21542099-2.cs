    [JsonConverter(typeof(NodeConverter))]
    class Node
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Node> children { get; set; }
    }
