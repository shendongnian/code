    class CustomTypeDescriptor : System.ComponentModel.CustomTypeDescriptor
    {
        private List<PropertyDescriptor> propertyDescriptors = new List<PropertyDescriptor>();
        private PropertyDescriptorCollection propertyDescriptorCollection;
    
        public CustomTypeDescriptor(ICustomTypeDescriptor parent, object instance)
            : base(parent)
        {
            CustomTypeDescriptionProvider customTypeDescriptionProvider = new WpfApplication1.CustomTypeDescriptionProvider();
            ICustomTypeDescriptor typeDescriptor = customTypeDescriptionProvider.GetBaseTypeDescriptor(typeof(Party), null);
            PropertyDescriptorCollection tempPropertyDescriptorCollection = typeDescriptor.GetProperties();
            propertyDescriptors.Add(tempPropertyDescriptorCollection[2]);
            propertyDescriptors.Add(tempPropertyDescriptorCollection[1]);
            propertyDescriptors.Add(tempPropertyDescriptorCollection[0]);
            /* put here your ordering logic */
    
            propertyDescriptorCollection = new PropertyDescriptorCollection(propertyDescriptors.ToArray());
        }
            
        public override PropertyDescriptorCollection GetProperties()
        {
            return propertyDescriptorCollection;
        }
    
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return propertyDescriptorCollection;
        }
    }
