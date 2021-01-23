    public class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(
            MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (!property.HasMemberAttribute || 
                property.PropertyName == property.UnderlyingName)
            {
                property.PropertyName += "_";
            }
            return property;
        }
    }
