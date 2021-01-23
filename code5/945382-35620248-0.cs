    public sealed class SubstituteNullWithEmptyStringContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty property in properties)
            {
                if (property.PropertyType == typeof(string)) {
                    property.ValueProvider = new NullToEmptyStringValueProvider(property.ValueProvider);
                }
            }
            return properties;
        }
        sealed class NullToEmptyStringValueProvider : IValueProvider
        {
            private readonly IValueProvider Provider;
            public NullToEmptyStringValueProvider(IValueProvider provider)
            {
                Provider = provider;
            }
            public object GetValue(object target)
            {
                object value = Provider.GetValue(target);
                return value == null ? "" : value;
            }
            public void SetValue(object target, object value)
            {
                Provider.SetValue(target, value);
            }
        }
    }
