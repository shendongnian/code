    public class SomeConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("SomeConfig", IsRequired = true)]
        public string SomeConfig
        {
            get { return (string)base["SomeConfig"]; }
            set { base["SomeConfig"] = value; }
        }
        XElement _SomeParam;
        public XElement SomeParam
        {
            get { return _SomeParam; }
        }
        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            if (elementName == "SomeParam")
            {
                _SomeParam = (XElement)XElement.ReadFrom(reader);
                return true;
            }
            else
                return base.OnDeserializeUnrecognizedElement(elementName, reader);
        }
    }
