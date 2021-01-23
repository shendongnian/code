    public class Modifier : CustomReflectionContext
    {
        private string propName;
        private object propValue;
        public Modifier(string propName, object propValue)
        {
            this.propName = propName;
            this.propValue = propValue;
        }
        protected override IEnumerable<PropertyInfo> AddProperties(Type type)
        {
            Type newType = MapType(propValue.GetType().GetTypeInfo());
            return CreateProperty(newType, propName, o => propValue, (o, v) => propValue = v,
                                        new Attribute[] { new KeyAttribute() }, new Attribute[] { }, new Attribute[] { });
        }
        protected override IEnumerable<object> GetCustomAttributes(MemberInfo member, IEnumerable<object> declaredAttributes)
        {
            return new Attribute[] { };
        }
    }
