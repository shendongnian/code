    public class InterfaceToClassConverter<TInterface, TClass> : JavaScriptConverter where TClass : class, TInterface
    {
        public InterfaceToClassConverter()
        {
            if (typeof(TInterface) == typeof(TClass))
                throw new ArgumentException(string.Format("{0} and {1} must not be the same type", typeof(TInterface).FullName, typeof(TClass).FullName)); // Or else you would get infinite recursion!
            if (!typeof(TInterface).IsInterface)
                throw new ArgumentException(string.Format("{0} must be an interface", typeof(TInterface).FullName));
            if (typeof(TClass).IsInterface)
                throw new ArgumentException(string.Format("{0} must be a class not an interface", typeof(TClass).FullName));
        }
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (type == typeof(TInterface))
                return serializer.ConvertToType<TClass>(dictionary);
            return null;
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                // For an interface-valued property such as "IFoo  Foo { getl set; },
                // When serializing, JavaScriptSerializer knows the actual concrete type being serialized -- which is never an interface.
                // When deserializing, JavaScriptSerializer only knows the expected type, which is an interface.  Thus by returning
                // only typeof(TInterface), we ensure this converter will only be called during deserialization, not serialization.
                return new[] { typeof(TInterface) };
            }
        }
    }
