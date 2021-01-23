    public class ItemConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Item);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            string group = (string)jo["group"];
            if (group == "Manufacturing")
            {
                return jo.ToObject<ManufacturingItem>(serializer);
            }
            else if (group == "Roll")
            {
                return jo.ToObject<RollItem>(serializer);
            }
            else if (group == "Weld")
            {
                return jo.ToObject<WeldItem>(serializer);
            }
            throw new JsonSerializationException("Unexpected item (group) type");
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
