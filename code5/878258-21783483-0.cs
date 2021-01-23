    class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            foreach (var property in properties)
            {
                property.PropertyName = char.ToLower(property.PropertyName[0]) + string.Join("", property.PropertyName.Skip(1));
            }
            return properties;
        }
    }
