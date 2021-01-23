    public class SerializeMe
    {
        [JsonConverter(typeof(ObjectJsonConverter))]
        public JsoSerializableObjectContainer VisualData { get; set; } = new JsoSerializableObjectContainer();
    }
    public class JsoSerializableObjectContainer
    {
        public string ObjectTypeAssemblyName { get; set; }
        public string ObjectTypeName { get; set; }
        public string ObjectTypeData { get; set; }
        [JsonIgnore]
        public object Data { get; set; }
    }
    public class ObjectJsonConverter : JsonConverter
    {
        private static Assembly[] _assemblies;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dataObj = (JsoSerializableObjectContainer) value;
            if (dataObj?.Data == null)
                return;
            var objType = dataObj.Data.GetType();
            dataObj.ObjectTypeName = objType.FullName;
            dataObj.ObjectTypeAssemblyName = objType.Assembly.FullName;
            dataObj.ObjectTypeData = JsonConvert.SerializeObject(dataObj.Data);
            var ser = JsonSerializer.Create();
            ser.Serialize(writer, dataObj);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonSerializer = JsonSerializer.Create();
            var container = jsonSerializer.Deserialize<JsoSerializableObjectContainer>(reader);
            if (container != null)
            {
                if (_assemblies == null)
                {
                    _assemblies = AppDomain.CurrentDomain.GetAssemblies();
                }
                var assembly = _assemblies.Single(t => t.FullName == container.ObjectTypeAssemblyName);
                var deserializationType = assembly.GetType(container.ObjectTypeName);
                if (deserializationType == null)
                {
                    throw new JsonException(
                        $"Can't find type for object deserialization {container.ObjectTypeName}"); //Probably type was deleted from code
                }
                var myObject = JsonConvert.DeserializeObject(container.ObjectTypeData, deserializationType);
                container.Data = myObject;
                return container;
            }
            return null;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(JsoSerializableObjectContainer);
        }
    }
