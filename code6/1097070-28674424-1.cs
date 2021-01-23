    public class MyTypeContractResolver<T> : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member,
                                                       MemberSerialization
                                                           memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.Ignored = false;
            property.ShouldSerialize = propInstance => property.DeclaringType != typeof (T);
            return property;
        }
    }
