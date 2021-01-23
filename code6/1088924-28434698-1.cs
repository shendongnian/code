    public class CustomTypeDescriptionProvider : TypeDescriptionProvider
    {
        private static TypeDescriptionProvider defaultTypeProvider =
                    TypeDescriptor.GetProvider(typeof(Party));
    
        public CustomTypeDescriptionProvider()
            : base(defaultTypeProvider)
        {
        }
    
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            ICustomTypeDescriptor defaultDescriptor =
                                base.GetTypeDescriptor(objectType, instance);
    
            return new CustomTypeDescriptor(defaultDescriptor, instance);
        }
    
        public ICustomTypeDescriptor GetBaseTypeDescriptor(Type objectType, object instance)
        {
            return base.GetTypeDescriptor(objectType, instance);
        }
    }
