    public abstract class XmlserializerKey
    {
        readonly Type serializerType;
        public XmlserializerKey(Type serializerType)
        {
            this.serializerType = serializerType;
        }
        protected Type SerializerType { get { return serializerType; } }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            else if (ReferenceEquals(null, obj))
                return false;
            if (GetType() != obj.GetType())
                return false;
            XmlserializerKey other = (XmlserializerKey)obj;
            if (other.serializerType != serializerType)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            int code = 0;
            if (serializerType != null)
                code ^= serializerType.GetHashCode();
            return code;
        }
        public override string ToString()
        {
            return string.Format("Serializer type: " + serializerType.ToString());
        }
    }
    public abstract class XmlserializerKeyWithExtraTypes : XmlserializerKey
    {
        static IEqualityComparer<HashSet<Type>> comparer;
        readonly HashSet<Type> moreTypes = new HashSet<Type>();
        static XmlserializerKeyWithExtraTypes()
        {
            comparer = HashSet<Type>.CreateSetComparer();
        }
        public XmlserializerKeyWithExtraTypes(Type serializerType, IEnumerable<Type> extraTypes)
            : base(serializerType)
        {
            if (extraTypes != null)
                foreach (var type in extraTypes)
                    moreTypes.Add(type);
        }
        protected Type[] MoreTypes { get { return moreTypes.ToArray(); } }
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            XmlserializerKeyWithExtraTypes other = (XmlserializerKeyWithExtraTypes)obj;
            return comparer.Equals(moreTypes, other.moreTypes);
        }
        public override int GetHashCode()
        {
            int code = base.GetHashCode();
            if (moreTypes != null)
                code ^= comparer.GetHashCode(moreTypes);
            return code;
        }
    }
    public sealed class XmlSerializerKeyWithKnownTypes : XmlserializerKeyWithExtraTypes
    {
        public XmlSerializerKeyWithKnownTypes(Type serializerType, IEnumerable<Type> otherTypes)
            : base(serializerType, otherTypes)
        {
        }
        public XmlSerializer CreateSerializer()
        {
            return new XmlSerializer(SerializerType, MoreTypes);
        }
    }
    public static class XmlSerializerHashTable
    {
        static Dictionary<object, XmlSerializer> dict;
        static XmlSerializerHashTable()
        {
            dict = new Dictionary<object, XmlSerializer>();
        }
        public static XmlSerializer DemandSerializer(object key, Func<object, XmlSerializer> factory)
        {
            lock (dict)
            {
                XmlSerializer value;
                if (!dict.TryGetValue(key, out value))
                    dict[key] = value = factory(key);
                return value;
            }
        }
    }
    public static class XmlSerializerWithKnownDerivedTypesCreator
    {
        public static XmlSerializer CreateKnownTypeSerializer(Type type, IEnumerable<Type> extraTypes)
        {
            var allExtraTypes = 
                AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => extraTypes.Any(extraType => extraType.IsAssignableFrom(t)));
            var key = new XmlSerializerKeyWithKnownTypes(type, allExtraTypes);
            return XmlSerializerHashTable.DemandSerializer(key, k => ((XmlSerializerKeyWithKnownTypes)k).CreateSerializer());
        }
    }
