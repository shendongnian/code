    public class Person : IPerson
    {
    
        public string FullName { get; set; }
        public eOperationType OpType { get { return eOperationType.Person; } }
        public void ProcessXml(XElement node)
        {
            var attr = node.Attributes().First (atr => atr.Name == "Name");
            FullName = attr.Value.ToString();
        }
    
    }
