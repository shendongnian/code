    public class DataSnapInConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(DataSnapIn) == (objectType);
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (this.CanConvert(objectType) == false) return null;
    
            var jo = JObject.Load(reader);
            var typeName = jo["snapInType"] ?? jo["SnapInType"];  //the abstract classes have this property to identify what concrete class they are.
            var typeNameString = typeName.ToString();
    
            var deserializeType = Type.GetType(typeNameString);
            if(deserializeType == null)
                throw new Exception("SnapInType is null or does not reference a valid class.");
    
            var result = Activator.CreateInstance(deserializeType);
            serializer.Populate(jo.CreateReader(), result);
    
            return result;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
