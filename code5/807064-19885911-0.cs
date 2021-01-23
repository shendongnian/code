    public class LaxPropertyNameMatchingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsClass;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
            PropertyInfo[] props = objectType.GetProperties();
            JObject jo = JObject.Load(reader);
            foreach (JProperty jp in jo.Properties())
            {
                string name = Regex.Replace(jp.Name, "[^A-Za-z0-9]+", "");
                
                PropertyInfo prop = props.FirstOrDefault(pi => 
                    pi.CanWrite && string.Equals(pi.Name, name, StringComparison.OrdinalIgnoreCase));
                if (prop != null)
                    prop.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
            }
            return instance;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
