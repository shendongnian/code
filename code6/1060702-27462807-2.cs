    public class LinkSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof (Link) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            //NOTE:I changed .ctor to publec to simplify the process, we can also check for JsonConstructor attribute on constructors and the call appropriate one
            var value = existingValue ?? Activator.CreateInstance(objectType, jObject["id"].Value<int>());
            Populate(objectType, jObject, value);
            var avatar = Activator.CreateInstance<Avatar>(); //Fill avatar object
            Populate(avatar.GetType(),jObject,avatar);
            objectType.GetProperty("AuthorAvatar").SetValue(value,avatar); //set avatar object
            return value;
        }
        private static void Populate(Type objectType, JObject jObject, object value)
        {
            var properties =
                objectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var p in properties)
            {
                var ignore = p.GetCustomAttribute<JsonIgnoreAttribute>();
                if (ignore != null)
                    continue;
                var custom = p.GetCustomAttribute<JsonPropertyAttribute>();
                var name = custom != null ? custom.PropertyName : p.Name;
                var token = jObject[name];
                var obj = token != null
                    ? token.ToObject(p.PropertyType)
                    : p.PropertyType.IsValueType ? Activator.CreateInstance(p.PropertyType) : null;
                p.SetValue(value, obj);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //we just want to deserialize the object so we don't need it here, but the implementation would be very similar to deserialization
        }
