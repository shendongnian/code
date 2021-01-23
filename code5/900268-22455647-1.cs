    public class MyCustomResponseConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(MyCustomResponse));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
            PropertyInfo[] props = objectType.GetProperties();
            JObject jo = JObject.Load(reader);
            foreach ( JProperty jp in jo.Properties() )
            {
                PropertyInfo prop = props.FirstOrDefault(pi =>
                    pi.CanWrite && string.Equals(pi.Name, jp.Name, StringComparison.OrdinalIgnoreCase));
                if ( prop != null )
                {
                    // Convert data object to what was passed in at T
                    if ( jp.Name == "data" )
                        prop.SetValue(instance, jo.SelectToken("data").ToObject(typeof(T)));
                    else
                        prop.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                }
            }
            return instance;
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
