    public class CustomPropertySortContractResolver : DefaultContractResolver
    {
        private const int MaxPropertiesPerContract = 1000;
    
        protected override IList CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            List members = GetSerializableMembers(type);
            if (members == null)
            {
                throw new JsonSerializationException("Null collection of seralizable members returned.");
            }
    
            var properties = new JsonPropertyCollection(type);
    
            foreach (MemberInfo member in members)
            {
                JsonProperty property = CreateProperty(member, memberSerialization);
                if (property != null)
                {
                    properties.AddProperty(property);
                }
            }
    
            IList orderedProperties = properties.OrderBy(p => p.Order + 
                (MaxPropertiesPerContract * GetTypeDepth(p.DeclaringType)) ?? -1).ToList();
            return orderedProperties;
        }
    
        private static int GetTypeDepth(Type type)
        {
            int depth = 0;
            while ((type = type.BaseType) != null)
            {
                depth++;
            }
    
            return depth;
        }
    }
