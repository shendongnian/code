    public class WeinCadDocumentConverter : JsonConverter
    {
        private readonly IKernel _Kernel;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var document = value as IWeinCadDocument;
            Debug.Assert(document != null, "document != null");
            AssertThatWeHaveACustomGuidSet(value);
            writer.WriteStartObject();
            writer.WritePropertyName("InstanceId");
            writer.WriteValue(document.InstanceId);
            writer.WritePropertyName("TypeId");
            writer.WriteValue(document.GetType().GUID);
            writer.WritePropertyName("Name");
            writer.WriteValue(document.Name);
            writer.WritePropertyName("Data");
            serializer.Serialize(writer, document.PersistentData);
            writer.WriteEndObject();
        }
        /// <summary>
        /// The object need a custom GuidAttribute to be set on the class otherwise the
        /// GUID may change between versions of the code or even runs of the applications.
        /// This Guid is used for identifying types from the document store and calling
        /// the correct factory. 
        /// </summary>
        /// <param name="value"></param>
        private static void AssertThatWeHaveACustomGuidSet(object value)
        {
            var attr = System.Attribute.GetCustomAttributes(value.GetType())
                             .Where(a => a is GuidAttribute)
                             .ToList();
            if (attr.Count == 0)
                throw new ArgumentException
                    (String.Format
                         (@"Type '{0}' does not have a custom GuidAttribute set. Refusing to serialize.",
                          value.GetType().Name),
                     "value");
        }
        public override object ReadJson
            (JsonReader reader,
             Type objectType,
             object existingValue,
             JsonSerializer serializer)
        {
            JObject json = JObject.Load(reader);
            var props = json.Properties().ToList();
            var instanceId = (Guid) props[0].Value;
            var typeId = (Guid) props[1].Value;
            var name = (string) props[2].Value;
            var data = props[3].Value;
            var document = _Kernel.Get<IWeinCadDocument>(typeId.ToString());
            document.PersistentData = data;
            document.InstanceId = instanceId;
            document.Name = name;
            return document;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (IWeinCadDocument).IsAssignableFrom(objectType);
        }
        public WeinCadDocumentConverter(IKernel kernel)
        {
            _Kernel = kernel;
        }
    }
