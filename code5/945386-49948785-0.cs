    public sealed class SubstituteNullWithEmptyStringContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyType == typeof(string))
            {
                // Wrap value provider supplied by Json.NET.
                property.ValueProvider = new NullToEmptyStringValueProvider(property.ValueProvider, property.NullValueHandling);
            }
            return property;
        }
        sealed class NullToEmptyStringValueProvider : IValueProvider
        {
            private readonly IValueProvider Provider;
            private readonly NullValueHandling? NullHandling;
            public NullToEmptyStringValueProvider(IValueProvider provider, NullValueHandling? nullValueHandling)
            {
                Provider = provider ?? throw new ArgumentNullException("provider");
                NullHandling = nullValueHandling;
            }
            public object GetValue(object target)
            {
                if (NullHandling.HasValue 
                    && NullHandling.Value == NullValueHandling.Ignore
                    && Provider.GetValue(target) == null )
                {
                    return null;
                }
                return Provider.GetValue(target) ?? "";
            }
            public void SetValue(object target, object value)
            {
                Provider.SetValue(target, value);
            }
        }
    }
