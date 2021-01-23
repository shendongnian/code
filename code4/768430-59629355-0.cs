    class GenericControlDescriptionProvider : TypeDescriptionProvider
    {
        public GenericControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(ContainerControl)))
        {
        }
        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType.IsGenericType)
            {
                return objectType.BaseType;
            }
            return base.GetReflectionType(objectType, instance);
        }
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType.IsGenericType)
            {
                objectType = objectType.BaseType;
            }
            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
