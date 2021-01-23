    public class CustomAttributeProvider : ICustomAttributeProvider
    {
        private readonly object[] _attributes;
        public CustomAttributeProvider(params Attribute[] attributes)
        {
            _attributes = attributes;
        }
        public CustomAttributeProvider(AttributeCollection attributeCollection)
            : this(attributeCollection.OfType<Attribute>().ToArray())
        {
        }
        public object[] GetCustomAttributes(bool inherit)
        {
            return _attributes;
        }
        public object[] GetCustomAttributes(Type attributeType, bool inherit)
        {
            return _attributes.Where(attributeType.IsInstanceOfType).ToArray();
        }
        public bool IsDefined(Type attributeType, bool inherit)
        {
            return _attributes.Any(attributeType.IsInstanceOfType);
        }
    }
