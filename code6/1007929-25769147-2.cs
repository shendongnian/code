    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public static ShouldSerializeContractResolver Instance { get; } = new ShouldSerializeContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);        
            if (typeof(Account).IsAssignableFrom(member.DeclaringType) && member.Name == nameof(Account.PasswordHash))
            {
                property.Ignored = true;
            }
            return property;
        }
    }
