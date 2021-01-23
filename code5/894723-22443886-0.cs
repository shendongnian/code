    [TypeConverter(typeof(CustomerObjectConverter))]
    public class Customer
    {
        internal readonly int ServerId;
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer(int serverId)
        {
            ServerId = serverId;
        }
        public override string ToString()
        {
            return Id + ", " + Name;
        }
    }
    public class CustomerCollection : CollectionBase, ICustomTypeDescriptor
    {
        public CustomerCollection()
        {
        }
        public CustomerCollection(IEnumerable<Customer> collection)
        {
            foreach (var item in collection)
                Add(item);
        }
        public void Add(Customer emp)
        {
            List.Add(emp);
        }
        public void Remove(Customer emp)
        {
            List.Remove(emp);
        }
        public Customer this[int index]
        {
            get { return (Customer)List[index]; }
        }
        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }
        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
            for (int i = 0; i < List.Count; i++)
            {
                CustomersCollectionPropertyDescriptor pd = new CustomersCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            return pds;
        }
    }
    internal class CustomersCollectionPropertyDescriptor : PropertyDescriptor
    {
        private readonly CustomerCollection collection;
        private readonly int index = -1;
        public CustomersCollectionPropertyDescriptor(CustomerCollection coll, int idx)
            : base("#" + idx.ToString(), null)
        {
            collection = coll;
            index = idx;
        } 
        public override AttributeCollection Attributes
        {
            get { return new AttributeCollection(null); }
        }
        public override string Category
        {
            get { return "Server " + collection[index].ServerId; }
        }
        public override bool CanResetValue(object component)
        {
            return true;
        }
        public override Type ComponentType
        {
            get { return collection.GetType(); }
        }
        public override string DisplayName
        {
            get { return "Customer " + (index + 1); }
        }
        public override string Description
        {
            get { return "Customer"; }
        }
        public override object GetValue(object component)
        {
            return collection[index];
        }
        public override bool IsReadOnly
        {
            get { return true;  }
        }
        public override string Name
        {
            get { return "#" + index.ToString(); }
        }
        public override Type PropertyType
        {
            get { return collection[index].GetType(); }
        }
        public override void ResetValue(object component) {}
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
        public override void SetValue(object component, object value)
        {
        }
    }
    internal class CustomerObjectConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return false;
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return destinationType == typeof(string) && value is Customer
                       ? value.ToString()
                       : base.ConvertTo(context, culture, value, destinationType);
        }
    }
