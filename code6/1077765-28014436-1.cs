    public class Vector4Converter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vector4);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var vec = new Vector4();
            if (token["X"] != null)
                vec.X = (float)token["X"];
            if (token["Y"] != null)
                vec.Y = (float)token["Y"];
            if (token["Z"] != null)
                vec.Z = (float)token["Z"];
            if (token["W"] != null)
                vec.W = (float)token["W"];
            return vec;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Vector4 vectorValue = (Vector4)value;
            writer.WriteStartObject();
            writer.WritePropertyName("X");
            writer.WriteValue(vectorValue.X);
            writer.WritePropertyName("Y");
            writer.WriteValue(vectorValue.Y);
            writer.WritePropertyName("Z");
            writer.WriteValue(vectorValue.Z);
            writer.WritePropertyName("W");
            writer.WriteValue(vectorValue.W);
            writer.WriteEndObject();
        }
    }
