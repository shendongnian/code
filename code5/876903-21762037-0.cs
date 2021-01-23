    class ViewConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(View));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            View view = (View)value;
            JObject jo = new JObject();
            jo.Add("Id", view.Id);
            if (view.ElementData != null)
            {
                jo.Add(view.ElementData.GetType().Name, JObject.FromObject(view.ElementData));
            }
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
