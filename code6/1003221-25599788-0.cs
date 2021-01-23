     class CustomResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.PropertyName.Contains("Specified"))
            {
                prop.ShouldSerialize = obj => false;
            }
            return prop;
        }
    }
