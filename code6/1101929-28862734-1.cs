    public partial class LocationType
    {
        [XmlIgnore]
        public string Address
        {
            get
            {
                return (string)XmlPolymorphicArrayHelper.GetItem(Items, ItemsElementName, ItemsChoiceType.Address);
            }
            set
            {
                XmlPolymorphicArrayHelper.SetItem(ref this.itemsField, ref this.itemsElementNameField, ItemsChoiceType.Address, value);
            }
        }
    }
