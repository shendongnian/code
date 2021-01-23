    class MyClassTypeDescProvider<T> : TypeDescriptionProvider
    {
        private ICustomTypeDescriptor td;
        public DigiRecordBindingTypeDescProvider()
            : this(TypeDescriptor.GetProvider(typeof(MyClass)))
        { }
        public MyClassTypeDescProvider(TypeDescriptionProvider parent)
            : base(parent)
        { }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            if (td == null)
            {
                td = base.GetTypeDescriptor(objectType, instance);
                td = new MyClassTypeDescriptors(td, typeof(T));
            }
            return td;
        }
    }
