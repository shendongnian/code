    public class MyConfigInstanceCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MyConfigInstanceElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            //set to whatever Element Property you want to use for a key
            return ((MyConfigInstanceElement)element).Name;
        }
        public new MyConfigInstanceElement this[string key]
        {
            get { return BaseGet(key) as MyConfigInstanceElement; }
        }
    }
