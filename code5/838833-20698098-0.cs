    public class DollarIdPreservingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FormDefinition);
        }
        public override object ReadJson(JsonReader reader, Type objectType,
                               object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            object o = jo.ToObject(objectType);
            JToken id = jo["$id"];
            if (id != null)
            {
                PropertyInfo prop = objectType.GetProperty("Id");
                if (prop != null && prop.CanWrite && 
                    prop.PropertyType == typeof(string))
                {
                    prop.SetValue(o, id.ToString());
                }
            }
            return o;
        }
        public override void WriteJson(JsonWriter writer, object value, 
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
