    public class MyContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<Newtonsoft.Json.Serialization.JsonProperty> CreateProperties(Type type, Newtonsoft.Json.MemberSerialization memberSerialization)
        {
            //Find methods.  setXXX getXXX
            var properties = type.GetMethods()
                .Where(m => m.Name.Length > 3)
                .GroupBy(m => m.Name.Substring(3))
                .Where(g => g.Count() == 2 && g.Any(x=>x.Name=="set" + g.Key) && g.Any(x=>x.Name=="get" + g.Key))
                .ToList();
            //Create a JsonProperty for each set/getXXX pair
            var ret = properties.Select(prop=>
                        {
                            var jProp = new Newtonsoft.Json.Serialization.JsonProperty();
                            jProp.PropertyName = prop.Key;
                            jProp.PropertyType = prop.First(m => m.Name.StartsWith("get")).ReturnType;
                            jProp.ValueProvider = new MyValueProvider(prop.ToList());
                            jProp.Readable = jProp.Writable = true;
                            return jProp;
                        })
                        .ToList();
            return ret;
        }
    }
    public class MyValueProvider : Newtonsoft.Json.Serialization.IValueProvider
    {
        List<MethodInfo> _MethodInfos = null;
        public MyValueProvider(List<MethodInfo> methodInfos)
        {
            _MethodInfos = methodInfos;
        }
        public object GetValue(object target)
        {
            return _MethodInfos.First(m => m.Name.StartsWith("get")).Invoke(target, null);
        }
        public void SetValue(object target, object value)
        {
            _MethodInfos.First(m => m.Name.StartsWith("set")).Invoke(target, new object[] { value });
        }
    }
