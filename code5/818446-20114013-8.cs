    public class DataContainerConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(DataContainer));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            DataContainer container = new DataContainer();
            container.ID = jo["id"].Value<int>();
            container.Data = jo["attr"]["info"]["dat"].ToObject<List<Dat>>(serializer);
            return container;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DataContainer container = (DataContainer)value;
            JObject jo = new JObject();
            jo.Add("id", container.ID);
            JObject attr = new JObject();
            jo.Add("attr", attr);
            JObject info = new JObject();
            attr.Add("info", info);
            JArray dat = JArray.FromObject(container.Data, serializer);
            info.Add("dat", dat);
            jo.WriteTo(writer);
        }
    }
