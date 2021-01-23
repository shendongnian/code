    class IgnorePropertyResolver : DefaultContractResolver
    {
        Type targetType;
        string targetPropertyName;
        public IgnorePropertyResolver(Type targetType, string propertyName)
        {
            this.targetType = targetType;
            this.targetPropertyName = propertyName;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            if (targetType == type)
            {
                props = props.Where(p => p.PropertyName != targetPropertyName).ToList();
            }
            return props;
        }
    }
