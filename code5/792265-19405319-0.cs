    public class MyConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            var jsonObject = JObject.Load(reader);
            var value = Create(jsonObject);
            if (value == null)
            {
                throw new JsonSerializationException("No object created.");
            }
            serializer.Populate(jsonObject.CreateReader(), value);
            return value;
        }
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return typeof(Geometry).IsAssignableFrom(objectType);
        }
        private static object Create(JObject jsonObject)
        {
            if (jsonObject["type"] != null)
            {
                var typeName = jsonObject["type"].ToString();
                switch (typeName)
                {
                    case "MyConcreteInterfaceImplemation"
                        return new MyConcreteInterfaceImplemation();
                    default:
                        throw new InvalidOperationException("No supported type");
                }
            }
            throw new InvalidOperationException("No supported type");
        }
    }
