    public class CustomContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        private IEnumerable<string> propertyNames;
     
        public CustomContractResolver(IEnumerable<string> propertyNames)
        {
            this.propertyNames = propertyNames;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            return properties.Where(p => propertyNames.Contains(p.PropertyName)).ToList();
        }
    }
