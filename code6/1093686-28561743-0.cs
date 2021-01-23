    class MyContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var list = base.CreateProperties(type, memberSerialization);
            foreach (var prop in list)
            {
                prop.Ignored = false; // Don't ignore any property
            }
            return list;
        }
    }
