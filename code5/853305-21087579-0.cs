    internal sealed class ManagementObjectPropertDescriptor : PropertyDescriptor
    {
        private readonly PropertyData propertyData;
        public ManagementObjectPropertDescriptor(PropertyData propertyData)
            : base(propertyData.Name, null)
        {
            this.propertyData = propertyData;
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get { return typeof(ManagementObjectTypeDescriptor); }
        }
        public override object GetValue(object component)
        {
            return propertyData.Value;
        }
        public override bool IsReadOnly
        {
            get { return true; }
        }
        public override Type PropertyType
        {
            get { return propertyData.Value != null ? propertyData.Value.GetType() : typeof(object); }
        }
        public override void ResetValue(object component)
        {
        }
        public override void SetValue(object component, object value)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
    public sealed class ManagementObjectTypeDescriptor : CustomTypeDescriptor
    {
        private PropertyData[] managementObjectProperties;
        public ManagementObjectTypeDescriptor(ManagementBaseObject source)
        {
            this.managementObjectProperties = source
                .Properties
                .Cast<PropertyData>()
                .ToArray();
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return new PropertyDescriptorCollection(managementObjectProperties
                .Select(p => new ManagementObjectPropertDescriptor(p))
                .ToArray());
        }
    }
