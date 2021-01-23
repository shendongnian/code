    private class IgnoreSSNResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            Debug.Write(type.Name);
            var properties = base.CreateProperties(type, memberSerialization);
            var props = properties.Where((x) => x.PropertyName != "SSN");
         
            return props.ToList();
        }
    }
