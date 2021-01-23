    public class ObjectCollectionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType ==  typeof(object[]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            object[] collection = (object[])value;
            writer.WriteStartArray();
            foreach (var item in collection)
            {
                if (item == null)
                {
                    writer.WriteRawValue(""); // This procudes "nothing"
                }
                else
                {
                    writer.WriteValue(item);
                }
            }
            writer.WriteEndArray();
        }
    }
