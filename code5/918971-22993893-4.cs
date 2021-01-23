    class OriginalNameContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            // Let the base class create all the JsonProperties 
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
    
            // assign the C# property name
            foreach (JsonProperty prop in list)
            {
                prop.PropertyName = prop.UnderlyingName;
            }
    
            return list;
        }
    }
