    public static class XmlSerializationHelper
    {
        public static void SerializeElementTo<T>(T value, string elementName, string elementNamespace, XmlWriter writer, XmlSerializerNamespaces ns)
        {
            var serializer = XmlSerializerRootAttributeCache.DemandSerializer(value.GetType(), elementName, elementNamespace);
            serializer.Serialize(writer, value, ns);
        }
        public static string GetXml<T>(this T obj)
        {
            return GetXml(obj, false);
        }
        public static string GetXml<T>(this T obj, bool omitNamespace)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), omitNamespace);
        }
        public static string GetXml<T>(this T obj, XmlSerializer serializer)
        {
            return GetXml(obj, serializer, false);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, bool omitStandardNamespaces)
        {
            XmlSerializerNamespaces ns = null;
            if (omitStandardNamespaces)
            {
                ns = new XmlSerializerNamespaces();
                ns.Add("", ""); // Disable the xmlns:xsi and xmlns:xsd lines.
            }
            return GetXml(obj, serializer, ns);
        }
        public static string GetXml<T>(T obj, XmlSerializer serializer, XmlSerializerNamespaces ns)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true, IndentChars = "    " }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    serializer.Serialize(xmlWriter, obj, ns);
                return textWriter.ToString();
            }
        }
        public static string GetXml<T>(this T obj, XmlSerializerNamespaces ns)
        {
            return GetXml(obj, new XmlSerializer(obj.GetType()), ns);
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
