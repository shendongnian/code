    public class ModuleObjectConverter : JsonCreationConverter<Module>
    {
        protected override Module Create(Type objectType, JObject jObject)
        {
            //This is the important part - we can query what json properties are present
            //to figure out what type of object to construct and populate
            if (FieldExists("amount", jObject)) {
                return new Wheel();
            } else if (FieldExists("delay", jObject)) {
                return new Break();
            } else {
                return null;
            }
        }
    
        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //We don't deal with writing json, generally newtonsoft would make a good job of
            //serializing these type of objects without having to use a custom writer anyway
        }
    }
    
    //Generic converter class - could combine with above class if you're only dealing
    //with one inheritance chain, but this way it's reusable
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);
    
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
    
            // Create target object based on JObject
            T target = Create(objectType, jObject);
    
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
    
            return target;
        }
    }
