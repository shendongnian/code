    [Serializable]
    public class Cache : JSONNode
    {
        public List<string> ElementKeys { get; set; }
        public List<JSONNode> ElementValues { get; set; }
    }
