    public partial class LocationType
    {
        public LocationType() { }
        public LocationType(string locNum)
        {
            SetIndirectLocation(locNum);
        }
        public LocationType(string name, string address, string city, string state)
        {
            SetDirectLocation(name, address, city, state);
        }
        public bool IsIndirectLocation
        {
            get
            {
                return Array.IndexOf(ItemsElementName, ItemsChoiceType.LocNum) >= 0;
            }
        }
        public string Address { get { return (string)XmlPolymorphicArrayHelper.GetItem(Items, ItemsElementName, ItemsChoiceType.Address); } }
        public string LocNum { get { return (string)XmlPolymorphicArrayHelper.GetItem(Items, ItemsElementName, ItemsChoiceType.LocNum); } }
        // Other properties as desired.
        public void SetIndirectLocation(string locNum)
        {
            if (string.IsNullOrEmpty(locNum))
                throw new ArgumentException();
            object[] newItems = new object[] { locNum };
            ItemsChoiceType [] newItemsElementName = new ItemsChoiceType [] { ItemsChoiceType.LocNum };
            this.Items = newItems;
            this.ItemsElementName = newItemsElementName;
        }
        public void SetDirectLocation(string name, string address, string city, string state)
        {
            // In the schema, "City" is mandatory, others are optional.
            if (string.IsNullOrEmpty(city))
                throw new ArgumentException();
            List<object> newItems = new List<object>();
            List<ItemsChoiceType> newItemsElementName = new List<ItemsChoiceType>();
            if (name != null)
            {
                newItems.Add(name);
                newItemsElementName.Add(ItemsChoiceType.Name);
            }
            if (address != null)
            {
                newItems.Add(address);
                newItemsElementName.Add(ItemsChoiceType.Address);
            }
            newItems.Add(city);
            newItemsElementName.Add(ItemsChoiceType.City);
            if (state != null)
            {
                newItems.Add(state);
                newItemsElementName.Add(ItemsChoiceType.State);
            }
            this.Items = newItems.ToArray();
            this.ItemsElementName = newItemsElementName.ToArray();
        }
    }
    public static class XmlPolymorphicArrayHelper
    {
        public static TResult GetItem<TIDentifier, TResult>(TResult[] items, TIDentifier[] itemIdentifiers, TIDentifier itemIdentifier)
        {
            if (itemIdentifiers == null)
            {
                Debug.Assert(items == null);
                return default(TResult);
            }
            Debug.Assert(items.Length == itemIdentifiers.Length);
            var i = Array.IndexOf(itemIdentifiers, itemIdentifier);
            if (i < 0)
                return default(TResult);
            return items[i];
        }
    }
