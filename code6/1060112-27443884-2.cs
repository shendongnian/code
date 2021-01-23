    [ConfigurationCollection(typeof(ResourceItem), AddItemName = "item", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ResourceItemCollection : ConfigurationElementCollection
    {
        public ResourceItem this[int index]
        {
            get { return (ResourceItem)BaseGet(index); }
        }
        public new ResourceItem this[string name]
        {
            get { return (ResourceItem)BaseGet(name); }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ResourceItem();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ResourceItem)element).Title;
        }
    }
