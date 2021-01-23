    public class PolymorphicJsonConverter : JsonConverter
    {
        public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            JObject item = JObject.Load(reader);
            var type = item["type"].Value<string>();
            if (type == "SubClass1") {
                return item.ToObject<SubClass1>();
            } else if (type == "SubClass2") {
                return item.ToObject<SubClass2>();
            } else {
                return null;
            }
        }
        public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer) {
            JObject o = JObject.FromObject(value);
            if (value is SubClass1) {
                o.AddFirst(new JProperty("type", new JValue("SubClass1")));
            } else if (value is SubClass1) {
                o.AddFirst(new JProperty("type", new JValue("SubClass2")));
            }
            o.WriteTo(writer);
        }
        public override bool CanConvert (Type objectType) {
            return typeof(Base).IsAssignableFrom(objectType);
        }
    }
