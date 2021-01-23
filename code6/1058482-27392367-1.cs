    public static class XmlSerializerWithKnownTypeCreator<T>
    {
        static Dictionary<HashSet<Type>, XmlSerializer> table = new Dictionary<HashSet<Type>, XmlSerializer>(HashSet<Type>.CreateSetComparer());
        public static XmlSerializer CreateKnownTypeSerializer<TRoot>()
        {
            return CreateKnownTypeSerializer(new Type [] {typeof(TRoot)});
        }
        public static XmlSerializer CreateKnownTypeSerializer(IEnumerable<Type> baseTypes)
        {
            var set = new HashSet<Type>(
                AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => baseTypes.Any(baseType => baseType.IsAssignableFrom(t))));
            lock (table)
            {
                XmlSerializer serializer;
                if (table.TryGetValue(set, out serializer))
                    return serializer;
                table[set] = serializer = new XmlSerializer(typeof(T), set.ToArray());
                return serializer;
            }
        }
    }
