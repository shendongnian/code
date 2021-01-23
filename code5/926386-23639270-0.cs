    public class BetterXmlMediaTypeFormatter : XmlMediaTypeFormatter
    {
        private ConcurrentDictionary<Type, object> serializerCache = new ConcurrentDictionary<Type, object>();
        protected override object GetSerializer(Type type, object value, HttpContent content)
        {
            return this.GetSerializerForType(type);
        }
        protected override object GetDeserializer(Type type, HttpContent content)
        {
            return this.GetSerializerForType(type);
        }
        private static object CreateDefaultSerializer(Type type, bool throwOnError)
        {
            Exception exception = null;
            object serializer = null;
            try
            {
                new XsdDataContractExporter().GetRootElementName(type);
                serializer = new DataContractSerializer(type, new DataContractSerializerSettings() { SerializeReadOnlyTypes = true });
            }
            catch (Exception caught)
            {
                exception = caught;
            }
            if (serializer == null && throwOnError)
            {
                throw new InvalidOperationException("Failed to create the serializer for type " + type.Name, exception);
            }
            return serializer;
        }
        private object GetCachedSerializer(Type type, bool throwOnError)
        {
            object serializer;
            if (!this.serializerCache.TryGetValue(type, out serializer))
            {
                serializer = CreateDefaultSerializer(type, throwOnError);
                this.serializerCache.TryAdd(type, serializer);
            }
            return serializer;
        }
        private object GetSerializerForType(Type type)
        {
            Contract.Assert(type != null, "Type cannot be null");
            object serializer = this.GetCachedSerializer(type, true);
            if (serializer == null)
            {
                throw new InvalidOperationException();
            }
            return serializer;
        }
