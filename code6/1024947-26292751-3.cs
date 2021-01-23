    public class OmitPropertyContractResolver
           : IContractResolver
    {
        private readonly string[] _ignoredProperties;
        private readonly IContractResolver _resolver;
        public OmitPropertyContractResolver(IContractResolver resolver, params string[] ignoredProperties)
        {
            _ignoredProperties = ignoredProperties;
            _resolver = resolver;        
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = _resolver.CreateProperties(type, memberSerialization);
            return properties
                   .Where(p => _ignoredProperties.Contains(p.Name) == false)
                   .ToList();
        }
    }
