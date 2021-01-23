    public class SkipEmptyContractResolver : DefaultContractResolver
    {
        public SkipEmptyContractResolver (bool shareCache = false) : base(shareCache) { }
        protected override JsonProperty CreateProperty (MemberInfo member,
                MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            bool isDefaultValueIgnored =
                ((property.DefaultValueHandling ?? DefaultValueHandling.Ignore)
                    & DefaultValueHandling.Ignore) != 0;
            if (isDefaultValueIgnored
                    && !typeof(string).IsAssignableFrom(property.PropertyType)
                    && typeof(IEnumerable).IsAssignableFrom(property.PropertyType)) {
                var memberProp = member as PropertyInfo;
                var memberField = member as FieldInfo;
                Predicate<object> newShouldSerialize = obj => {
                    object value = memberProp != null
                        ? memberProp.GetValue(obj)
                        : memberField != null
                        ? memberField.GetValue(obj)
                        : null;
                    var collection = value as ICollection;
                    return collection == null || collection.Count != 0;
                };
                Predicate<object> oldShouldSerialize = property.ShouldSerialize;
                property.ShouldSerialize = oldShouldSerialize != null
                    ? o => oldShouldSerialize(o) && newShouldSerialize(o)
                    : newShouldSerialize;
            }
            return property;
        }
    }
