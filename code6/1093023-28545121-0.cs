    class CustomResolver : DefaultContractResolver
    {
        string rootName;
        public CustomResolver(string rootName)
        {
            this.rootName = rootName;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(RootObject<>))
            {
                JsonProperty prop = props.First(p => p.UnderlyingName == "Data");
                prop.PropertyName = this.rootName;
            }
            return props;
        }
    }
