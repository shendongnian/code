    public class GenericDeserializer<T> : IGenericDeserializer
    {
        private readonly IDictionary<TypeAndVersion, Type> _configuration;
        public GenericDeserializer(IDictionary<TypeAndVersion, Type> configuration)
        {
            _configuration = configuration;
        }
        public T Deserialize(string messageData, IMetaData metaData)
        {
            var typeAndVersion = new TypeAndVersion(metaData.MessageType, metaData.MessageTypeVersion);
            if (!_configuration.ContainsKey(typeAndVersion))
                throw new InvalidOperationException("Invalid version");
            return (T)JsonConvert.DeserializeObject(messageData, _configuration[typeAndVersion]);
        }
    }
