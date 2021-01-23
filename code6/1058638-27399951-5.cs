    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            property.ShouldSerialize = (i) =>
                {
                    //Your logic goes here
                    var r = !property.PropertyName.StartsWith("block-ref");
                    return r;
                };
            return property;
        }
    }
