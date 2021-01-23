    [ConfigurationCollection(typeof(SiteElement)[
    public class SiteElementCollection : ConfigurationElementCollection
        public SiteElement this[string name]
        {
            get
            {
                return (SiteElement)base.BaseGet(name);
            }
        }
      
        public SiteElement this[int index]
        {
            get
            {
                return (SiteElement)base.BaseGet(index);
            }
        }
        public override ConfigurationElement CreateNewElement()
        {
            return new SiteElement();
        }
        public override object GetElementKey(ConfigurationElement element)
        {
            return ((SiteElement)element).AddressKey;
        }
