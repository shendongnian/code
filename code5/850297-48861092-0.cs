     public class CustomConverter : JsonConverter
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer();
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var typeString = jObject.Value<string>("Kind"); //Kind is a property in json , from which we know type of child classes
            var requiredType = RecoverType(typeString);
            return Serializer.Deserialize(jObject.CreateReader(), requiredType);
        }
        private Type RecoverType(string typeString)
        {
            if (typeString.Equals(type of child class1, StringComparison.OrdinalIgnoreCase))
                return typeof(childclass1);
            if (typeString.Equals(type of child class2, StringComparison.OrdinalIgnoreCase))
                return typeof(childclass2);            
            
            throw new ArgumentException("Unrecognized type");
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Base class).IsAssignableFrom(objectType) || typeof((Base class) == objectType;
        }
        public override bool CanWrite { get { return false; } }
    }
