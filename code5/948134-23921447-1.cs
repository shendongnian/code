    public class GameConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Game<T>));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Game<T> game = new Game<T>();
            game.dateTime = jo["dateTime"].ToString();
            game.matchId = jo["matchId"].ToString();
            game.items = new Dictionary<string, T>();
            foreach (JProperty prop in jo.Properties())
            {
                if (prop.Value.Type == JTokenType.Object)
                {
                    game.items.Add(prop.Name, prop.Value.ToObject<T>());
                }
            }
            return game;
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
