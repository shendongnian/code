    public class JsonNodes
    {
        public string Node { get; set; }
        public string NodeValue { get; set; }
        public string ParentNode { get; set; }
        public List<JsonNodes> Nodes { get; set; }
        public List<JsonNodesAttribute> Attributes { get; set; }
    }
    public class JsonNodesAttribute
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
