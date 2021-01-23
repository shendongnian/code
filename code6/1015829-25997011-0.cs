    [Serializable]
    public class TestClass
    {
        [XmlText(typeof(string))]
        [XmlAnyElement]
        public object[] Items { get; set; }
    }
