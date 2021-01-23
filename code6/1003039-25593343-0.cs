    public class JsonAlbumConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
                return serializer.Deserialize<List<Album>>(reader);
            var itm = serializer.Deserialize<Album>(reader);
            return new List<Album> {itm};
        }
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
