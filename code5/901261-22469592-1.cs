    class ShapeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Shape));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Shape shape = new Shape();
            shape.Id = (int)jo["_id"];
            shape.Type = (string)jo["location"]["type"];
            JArray ja = (JArray)jo["location"]["coordinates"];
            if (shape.Type == "Point")
            {
                shape.Coordinates = new List<List<double>>();
                shape.Coordinates.Add(ja.ToObject<List<double>>());
            }
            else
            {
                shape.Coordinates = ja.ToObject<List<List<double>>>();
            }
            return shape;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
