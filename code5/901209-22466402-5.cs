    class CustomResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            if (typeof(ObjectBase).IsAssignableFrom(type))
            {
                string[] excludeThese = new string[] { "Id", "CreatedDate", "LastModifiedDate" };
                props = props.Where(p => !excludeThese.Contains(p.PropertyName)).ToList();
            }
            return props;
        }
    }
