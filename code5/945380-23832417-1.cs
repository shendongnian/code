    var settings = new JsonSerializerSettings
    {
        ContractResolver = new NullToEmptyStringResolver()
    };
    var str = JsonConvert.SerializeObject(yourObj, settings);
---
    public class NullToEmptyStringResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties().Select(property => CreateProperty(property, memberSerialization)).ToList();
        }
        private JsonProperty CreateProperty(PropertyInfo property, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(property, memberSerialization);
            jsonProperty.ValueProvider = new NullToEmptyStringValueProvider(jsonProperty.ValueProvider, property);
            return jsonProperty;
        }
        private class NullToEmptyStringValueProvider : IValueProvider
        {
            private readonly IValueProvider _valueProvider;
            private readonly PropertyInfo _property;
            public NullToEmptyStringValueProvider(IValueProvider valueProvider, PropertyInfo property)
            {
                _valueProvider = valueProvider;
                _property = property;
            }
            public object GetValue(object target)
            {
                var result = _valueProvider == null
                    ? _property.GetValue(target)
                    : _valueProvider.GetValue(target);
                if (_property.PropertyType == typeof(string) && result == null)
                {
                    result = string.Empty;
                }
                return result;
            }
            public void SetValue(object target, object value)
            {
                if (_valueProvider == null)
                {
                    _property.SetValue(target, value);
                }
                else
                {
                    _valueProvider.SetValue(target, value);
                }
            }
        }
    }
