    public class CustomSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof (CustomSerializer) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var value = existingValue ?? Activator.CreateInstance(objectType);
            PopulateAutoProperties(objectType, jObject, value);
            PopulateFields(objectType, jObject, value);
            return value;
        }
        private static void PopulateAutoProperties(Type objectType, JObject jObject, object value)
        {
            var properties =
                objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var p in properties.Where(IsAutoProperty))
            {
                var token = jObject[p.Name];
                var obj = token != null
                    ? token.ToObject(p.PropertyType)
                    : p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;
                
                p.SetValue(value, obj);
            }
        }
        private static void PopulateFields(Type objectType, JObject jObject, object value)
        {
            var fields =
                objectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var f in fields.Where(f => !f.Name.Contains("<")))
            {
                var token = jObject[f.Name];
                var obj = token != null
                    ? token.ToObject(f.FieldType)
                    : f.FieldType.IsValueType ? Activator.CreateInstance(f.FieldType) : null;
                f.SetValue(value, obj);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType=value.GetType();
            writer.WriteStartObject();
            WriteAutoProperties(writer, value, serializer, objectType);
            WriteFields(writer, value, serializer, objectType);
            writer.WriteEndObject();
        }
        private static void WriteFields(JsonWriter writer, object value, JsonSerializer serializer, Type objectType)
        {
            var fields = objectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var f in fields.Where(f => !f.Name.Contains("<")))
            {
                writer.WritePropertyName(f.Name);
                serializer.Serialize(writer, f.GetValue(value));
            }
        }
        private static void WriteAutoProperties(JsonWriter writer, object value, JsonSerializer serializer, Type objectType)
        {
            var properties =
                objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var p in properties.Where(IsAutoProperty))
            {
                writer.WritePropertyName(p.Name);
                serializer.Serialize(writer, p.GetValue(value));
            }
        }
        public static bool IsAutoProperty(PropertyInfo prop)
        {
            return prop.DeclaringType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                     .Any(f => f.Name.Contains("<" + prop.Name + ">"));
        }
    }
