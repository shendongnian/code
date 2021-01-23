    public class UserClass
    {
        public int ID { set; get; }
        public string Name {set; get;}
        public string SurName { set; get; }
    }
    public class CustomContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        IEnumerable<string> _allowedProps = null;
        public CustomContractResolver(IEnumerable<string> allowedProps)
        {
            _allowedProps = allowedProps;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var ss = type.GetProperty("SurName").PropertyType;
            return _allowedProps.Select(p=>new JsonProperty() {
                PropertyName = p,
                PropertyType = type.GetProperty(p).PropertyType,
                Readable = true,
                Writable = true,
                ValueProvider = base.CreateMemberValueProvider(type.GetMember(p).First())
            } ).ToList();
        }
    }
