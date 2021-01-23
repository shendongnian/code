    public abstract class XmlSerializerKey
    {
        static class XmlSerializerHashTable
        {
            static Dictionary<object, XmlSerializer> dict;
            static XmlSerializerHashTable()
            {
                dict = new Dictionary<object, XmlSerializer>();
            }
            public static XmlSerializer GetSerializer(XmlSerializerKey key)
            {
                lock (dict)
                {
                    XmlSerializer value;
                    if (!dict.TryGetValue(key, out value))
                        dict[key] = value = key.CreateSerializer();
                    return value;
                }
            }
        }
        readonly Type serializedType;
        protected XmlSerializerKey(Type serializedType)
        {
            this.serializedType = serializedType;
        }
        public Type SerializedType { get { return serializedType; } }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            else if (ReferenceEquals(null, obj))
                return false;
            if (GetType() != obj.GetType())
                return false;
            XmlSerializerKey other = (XmlSerializerKey)obj;
            if (other.serializedType != serializedType)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            int code = 0;
            if (serializedType != null)
                code ^= serializedType.GetHashCode();
            return code;
        }
        public override string ToString()
        {
            return string.Format(base.ToString() + ": for type: " + serializedType.ToString());
        }
        public XmlSerializer GetSerializer()
        {
            return XmlSerializerHashTable.GetSerializer(this);
        }
        protected abstract XmlSerializer CreateSerializer();
    }
    public abstract class XmlserializerWithExtraTypesKey : XmlSerializerKey
    {
        static IEqualityComparer<HashSet<Type>> comparer;
        readonly HashSet<Type> extraTypes = new HashSet<Type>();
        static XmlserializerWithExtraTypesKey()
        {
            comparer = HashSet<Type>.CreateSetComparer();
        }
        protected XmlserializerWithExtraTypesKey(Type serializedType, IEnumerable<Type> extraTypes)
            : base(serializedType)
        {
            if (extraTypes != null)
                foreach (var type in extraTypes)
                    this.extraTypes.Add(type);
        }
        public Type[] ExtraTypes { get { return extraTypes.ToArray(); } }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            XmlserializerWithExtraTypesKey other = (XmlserializerWithExtraTypesKey)obj;
            return comparer.Equals(this.extraTypes, other.extraTypes);
        }
        public override int GetHashCode()
        {
            int code = base.GetHashCode();
            if (extraTypes != null)
                code ^= comparer.GetHashCode(extraTypes);
            return code;
        }
    }
    public sealed class XmlSerializerIgnoringDefaultValuesKey : XmlserializerWithExtraTypesKey
    {
        readonly XmlAttributeOverrides overrides;
        private XmlSerializerIgnoringDefaultValuesKey(Type serializerType, IEnumerable<Type> ignoreDefaultTypes, XmlAttributeOverrides overrides)
            : base(serializerType, ignoreDefaultTypes)
        {
            this.overrides = overrides;
        }
        public static XmlSerializerIgnoringDefaultValuesKey Create(Type serializerType, IEnumerable<Type> ignoreDefaultTypes, bool recurse)
        {
            XmlAttributeOverrides overrides;
            Type [] typesWithOverrides;
            CreateOverrideAttributes(ignoreDefaultTypes, recurse, out overrides, out typesWithOverrides);
            return new XmlSerializerIgnoringDefaultValuesKey(serializerType, typesWithOverrides, overrides);
        }
        protected override XmlSerializer CreateSerializer()
        {
            var types = ExtraTypes;
            if (types == null || types.Length < 1)
                return new XmlSerializer(SerializedType);
            return new XmlSerializer(SerializedType, overrides);
        }
        static void CreateOverrideAttributes(IEnumerable<Type> types, bool recurse, out XmlAttributeOverrides overrides, out Type[] typesWithOverrides)
        {
            HashSet<Type> visited = new HashSet<Type>();
            HashSet<Type> withOverrides = new HashSet<Type>();
            overrides = new XmlAttributeOverrides();
            foreach (var type in types)
            {
                CreateOverrideAttributes(type, recurse, overrides, visited, withOverrides);
            }
            typesWithOverrides = withOverrides.ToArray();
        }
        static void CreateOverrideAttributes(Type type, bool recurse, XmlAttributeOverrides overrides, HashSet<Type> visited, HashSet<Type> withOverrides)
        {
            if (type == null || type == typeof(object) || type.IsPrimitive || type == typeof(string) || visited.Contains(type))
                return;
            var attrs = new XmlAttributes() { XmlDefaultValue = null };
            foreach (var property in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
                if (overrides[type, property.Name] == null) // Check to see if overrides for this base type were already set.
                    if (property.GetCustomAttributes<DefaultValueAttribute>(true).Any())
                    {
                        withOverrides.Add(type);
                        overrides.Add(type, property.Name, attrs);
                    }
            foreach (var field in type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public))
                if (overrides[type, field.Name] == null) // Check to see if overrides for this base type were already set.
                    if (field.GetCustomAttributes<DefaultValueAttribute>(true).Any())
                    {
                        withOverrides.Add(type);
                        overrides.Add(type, field.Name, attrs);
                    }
            visited.Add(type);
            if (recurse)
            {
                var baseType = type.BaseType;
                if (baseType != type)
                    CreateOverrideAttributes(baseType, recurse, overrides, visited, withOverrides);
            }
        }
    }
