    public sealed class MyJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(ProfileModel).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            ProfileModel target;
            JObject jObject = JObject.Load(reader);
            JToken resultToken = jObject["Result"];
            //This is result null check
            if (resultToken.Type == JTokenType.Null)
            {
                target = new ProfileModel();
            }
            else
            {
                var optionsModel = resultToken["DataLayout"].ToObject<DataLayoutOptionsModel>();
                target = new ProfileModel(optionsModel);
            }
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        public override void WriteJson(JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
