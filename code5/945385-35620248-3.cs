    public sealed class SubstituteNullWithEmptyStringContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyType == typeof(string))
            {
                // Wrap value provider supplied by Json.NET.
                property.ValueProvider = new NullToEmptyStringValueProvider(property.ValueProvider);
            }
            return property;
        }
        sealed class NullToEmptyStringValueProvider : IValueProvider
        {
            private readonly IValueProvider Provider;
            public NullToEmptyStringValueProvider(IValueProvider provider)
            {
                if (provider == null) throw new ArgumentNullException("provider");
                Provider = provider;
            }
            public object GetValue(object target)
            {
                return Provider.GetValue(target) ?? "";
            }
            public void SetValue(object target, object value)
            {
                Provider.SetValue(target, value);
            }
        }
    }
