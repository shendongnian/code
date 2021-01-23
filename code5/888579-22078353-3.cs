    internal sealed class MyTypeDescriptionProvider : TypeDescriptionProvider
    {
        private ICustomTypeDescriptor td;
        public MyTypeDescriptionProvider()
            : this(TypeDescriptor.GetProvider(typeof(MyFieldsClass)))
        {
        }
        public MyTypeDescriptionProvider(TypeDescriptionProvider parent)
            : base(parent)
        {
        }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return td ?? (td = new MyCustomTypeDescriptor(base.GetTypeDescriptor(objectType, instance)));
        }
    }
