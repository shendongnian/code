    public class CustomPropertySortContractResolver : DefaultContractResolver
    {
        private const int MaxPropertiesPerContract = 1000;
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var members = GetSerializableMembers(type);
            if (members == null)
            {
                throw new JsonSerializationException("Null collection of serializable members returned.");
            }
            return members.Select(member => CreateProperty(member, memberSerialization))
                          .Where(x => x != null)
                          .OrderBy(p => (p.Order
                                           + (MaxPropertiesPerContract * GetTypeDepth(p.DeclaringType))) 
                                        ?? -1)
                          .ToList();
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
