    public class RoomConverter : MyJsonConverter<Room_Types>
    {
        protected override Room_Types Create(Type objectType, JObject jObject)
        {
            var rooms = jObject.Cast<JToken>().Select(t => new Room
            {
                Type = ((JProperty)t).Name,
                Url = ((JProperty)t).First
                    .SelectToken("url").ToString(),
                Price = float.Parse(((JProperty)t).First
                    .SelectToken("price").ToString())
            }).ToList();
            return new Room_Types() { Rooms = rooms };
        }
        public override void WriteJson
            (JsonWriter writer, 
            object value, 
            JsonSerializer serializer)
        {
            writer.WriteStartObject();
            ((Room_Types)value).Rooms.ForEach(r =>
            {
                writer.WritePropertyName(r.Type);
                writer.WriteStartObject();
                writer.WritePropertyName("url");
                writer.WriteValue(r.Url);
                writer.WritePropertyName("price");
                writer.WriteValue(r.Price);
                writer.WriteEndObject();
            });
            writer.WriteEndObject();
        }
    }
