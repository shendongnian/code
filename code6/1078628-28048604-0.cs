    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
        return properties.Where(p => _propertiesToSerialize.Contains(string.Format("{0}.{1}", p.DeclaringType.Name, p.PropertyName))).ToList();
    }
