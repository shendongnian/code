    public partial class MyConfigurationElement : ConfigurationElement
    {
        private List<String> _propertyNames = new List<String>();
        :
        public String GetProperty(String propertyName)
        {
            if (_propertyNames.Contains(propertyName))
                return base[propertyName].ToString();
            else
                return null;
        }
        public void SetProperty(String propertyName, String value)
        {
            if (base.Properties.Contains(propertyName))
            {
                base.SetPropertyValue(base.Properties[propertyName], value, false);
            }
            else
            {
                ConfigurationProperty cp = new ConfigurationProperty(propertyName, typeof(String));
                base.Properties.Add(cp);
                base.SetPropertyValue(cp, value, false);
            }
            if (!_propertyNames.Contains(propertyName)) _propertyNames.Add(propertyName);
        }
        :
        protected override void DeserializeElement(System.Xml.XmlReader reader, bool serializeCollectionKey)
        {
            base.DeserializeElement(reader, serializeCollectionKey);
            if (reader.MoveToFirstAttribute() == true)
            {
                do
                {
                    _propertyNames.Add(reader.Name);
                } while (reader.MoveToNextAttribute());
                reader.MoveToElement();
            }
        }
    }
