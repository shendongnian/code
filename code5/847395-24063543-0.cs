    public class DbGeometryConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return objectType.IsAssignableFrom(typeof(string));
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject location = JObject.Load(reader);
                JToken token = location["Geometry"]["WellKnownText"];
                string value = token.ToString();
    
                DbGeometry converted = DbGeometry.PolygonFromText(value, 4326);
                return converted;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                // Base serialization is fine
                serializer.Serialize(writer, value);
            }
        }
