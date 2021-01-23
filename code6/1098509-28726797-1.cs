    JsonSerializerSettings settings = new JsonSerializerSettings 
    {
        ...
        ContractResolver= new MyCustomContractResolver() 
    };
    public class MyCustomContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties().Select( p => 
               {
                   var property = base.CreateProperty(p, memberSerialization);
                   property.ValueProvider = new MyCustomNullValueProvider(p);
                   return property;
               }).ToList();
        }
    }
    public class MyCustomNullValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public MyCustomNullValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }
        public object GetValue(object target)
        {
            object value = _MemberInfo.GetValue(target);
            if (value == null) 
               result = "{}";
            else
               return value; 
        }
        public void SetValue(object target, object value)
        {
            if ((string)value == "{}")
                value = null;
            _MemberInfo.SetValue(target, value);
        }
    }
