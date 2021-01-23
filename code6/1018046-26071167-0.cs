    [DataContract]
    [KnownType("KnownTypes")]
    class Entry<T>
    {
        [DataMember]
        public T Data { get; set; }
        public static IEnumerable<Type> KnownTypes()
        {
            var attrs = typeof(T).GetTypeInfo().GetCustomAttributes<KnownTypeAttribute>();
            return attrs.Select(attr => attr.Type);
        }
    }
