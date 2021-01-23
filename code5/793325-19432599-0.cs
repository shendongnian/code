    [Serializable]
    public class Spellement
    {
        public Spellement() { }
        List<Node> mapSave = new List<Node>();
        public List<Node> MapSave
        {
            get { return mapSave; }
            set { mapSave = value; }
        }
    }
    [Serializable]
    public class Node
    {
        public Node() { }
        public string Text { get; set; }
    }
    XmlSerializer xs = new XmlSerializer(typeof(Spellement));
    using (XmlWriter st = XmlWriter.Create("C:\\test.xml"))
    {
         xs.Serialize(st, s);
    }
