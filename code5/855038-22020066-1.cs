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
