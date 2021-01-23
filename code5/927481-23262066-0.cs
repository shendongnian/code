    [Serializable]
    [XmlInclude(typeof(ExtendedParams))]
    public class SerializeableTestClass
    {
        [XmlElement(ElementName = "Params")]
        public object Params;
    }
