    public class Property : IHasElementName
    {
        public Property()
        {
        }
        public Property(string name, int id, string value)
        {
            this.name = name;
            this.id = id;
            this.value = value;
        }
        [XmlIgnore]
        public string name; //could be enum
        public int id;
        public string value;
        #region IHasElementName Members
        [XmlIgnore]
        string IHasElementName.ElementName { get { return name; }  set { name = value; } }
        #endregion
    }
    public class RootObject
    {
        public RootObject()
        {
            this.Properties = new XmlNamedElementList<Property>();
        }
        public XmlNamedElementList<Property> Properties { get; set; }
    }
    public static class TestClass
    {
        public static void Test()
        {
            var root = new RootObject
            {
                // Characters " <> first" in the first element name are for testing purposes.
                Properties = new XmlNamedElementList<Property> { new Property { id = 1, value = "1", name = "first" }, new Property("property1name", 2, "testvalue"), new Property("property2name", 10, "anothervalue") }
            };
            var xml = root.GetXml();
            Debug.WriteLine(xml);
        }
    }
