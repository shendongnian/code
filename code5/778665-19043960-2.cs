    public class PostJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // not implemented
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // it must be an object being passed in, if not something went wrong!
            if (reader.TokenType != JsonToken.StartObject) throw new InvalidOperationException();
    
            var postToken = JToken.ReadFrom(reader);
            var userToken = postToken["%user%"];
            var venueToken = postToken["%venue%"];
            var messageToken = postToken["%message%"];
            return new Post
            {
                User = userToken == null ? null : userToken.ToObject<User>(),
                Venue = venueToken == null ? null : venueToken.ToObject<Venue>(),
                Message = messageToken == null ? null : messageToken.ToObject<Message>(),
            };
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
