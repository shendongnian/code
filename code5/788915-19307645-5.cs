    class ToyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // This lets JSON.Net know that this converter can handle Toy objects
            return (objectType == typeof(Toy));
        }
        public override object ReadJson(JsonReader reader, 
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            // load the toy JSON object into a JObject
            JObject jo = JObject.Load(reader);
            // get the first (and only) property of the object
            JProperty prop = jo.Properties().First();
            // deserialize the value of that property (which is another
            // object containing supplier and cost info) into a Toy instance
            Toy toy = prop.Value.ToObject<Toy>();
            // get the name of the property and add it to the newly minted toy
            toy.Name = prop.Name;
            return toy;
        }
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            // If you need to serialize Toys back into JSON, then you'll need
            // to implement this method.  We can skip it for now.
            throw new NotImplementedException();
        }
    }
