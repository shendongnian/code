    public static class XmlSerializationHelper
    {
        public static void SerializeElementTo<T>(T value, string elementName, string elementNamespace, XmlWriter writer, XmlSerializerNamespaces ns)
        {
            var serializer = XmlSerializerRootAttributeCache.DemandSerializer(value.GetType(), elementName, elementNamespace);
            serializer.Serialize(writer, value, ns);
        }
    }
    public static class XmlSerializerRootAttributeCache
    {
        readonly static Dictionary<Tuple<Type, string, string>, XmlSerializer> cache;
        readonly static object padlock = new object();
        static XmlSerializerRootAttributeCache()
        {
            cache = new Dictionary<Tuple<Type, string, string>, XmlSerializer>();
        }
        static XmlSerializer CreateSerializer(Type rootType, string rootName, string rootNamespace)
        {
            return new XmlSerializer(rootType, new XmlRootAttribute { ElementName = rootName, Namespace = rootNamespace });
        }
        public static XmlSerializer DemandSerializer(Type rootType, string rootName, string rootNamespace)
        {
            var key = Tuple.Create(rootType, rootName, rootNamespace);
            lock (padlock)
            {
                XmlSerializer serializer;
                if (!cache.TryGetValue(key, out serializer))
                    serializer = cache[key] = CreateSerializer(rootType, rootName, rootNamespace);
                return serializer;
            }
        }
    }
