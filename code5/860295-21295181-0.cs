    class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.DeclaringType != typeof(PseudoContext) && 
                prop.PropertyType.IsClass && 
                prop.PropertyType != typeof(string))
            {
                prop.ShouldSerialize = obj => false;
            }
            return prop;
        }
    }
