    class ListContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(
                            Type type, 
                            MemberSerialization memberSerialization)
        {
            var result = base.CreateProperties(type, memberSerialization);
            if(/*type is your type*/)
                result = result.Where(i=>i.PropertyName != "BigLongToSerializeObject")
                               .ToList();
            return result;
        }
    }
