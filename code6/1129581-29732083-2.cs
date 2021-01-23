    public class DefaultStringValueContractResolver : DefaultContractResolver
    {
        public string DefaultStringValue { get; set; }
        public DefaultStringValueContractResolver(string defaultStringValue)
        {
            this.DefaultStringValue = defaultStringValue;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            // Set all string properties to have a default value of "this is a default value"
            foreach (var property in properties.Where(p => p.PropertyType == typeof(string)))
            {
                property.DefaultValue = DefaultStringValue;
                property.DefaultValueHandling = DefaultValueHandling.Populate;
            }
            return properties;
        }
    }
