    class CustomResolver : DefaultContractResolver
    {
        private string customTypePropertyName;
        private IValueProvider valueProvider = new SimpleTypeNameProvider();
        public CustomResolver(string customTypePropertyName)
        {
            this.customTypePropertyName = customTypePropertyName;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            if (type.IsClass && type != typeof(string))
            {
                // Add a phantom string property to every class which will resolve 
                // to the simple type name of the class (via the value provider)
                // during serialization.
                props.Insert(0, new JsonProperty
                {
                    DeclaringType = type,
                    PropertyType = typeof(string),
                    PropertyName = customTypePropertyName,
                    ValueProvider = valueProvider,
                    Readable = true,
                    Writable = false
                });
            }
            return props;
        }
        class SimpleTypeNameProvider : IValueProvider
        {
            public object GetValue(object target)
            {
                return target.GetType().Name;
            }
            public void SetValue(object target, object value)
            {
                return;
            }
        }
    }
