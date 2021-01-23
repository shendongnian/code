    public partial class MyConfigurationElement : ConfigurationElement
    {
        private List<String> _propertyNames;
        :
        public String GetProperty(String propertyName)
        {
            if (_propertyNames.Contains(propertyName))
                return base[propertyName].ToString();
            else
                return null;
        }
        :
        protected override void DeserializeElement(System.Xml.XmlReader reader, bool serializeCollectionKey)
        {
            base.DeserializeElement(reader, serializeCollectionKey);
            _propertyNames = this.Properties.OfType<ConfigurationProperty>().Select(cp => cp.Name).ToList();
        }
    }
