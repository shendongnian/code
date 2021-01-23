    class SomeThingConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(SomeThing));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            SomeThing st = (SomeThing)value;
            JObject obj = new JObject();
            obj.Add("alpha", st.Alpha);
            obj.Add("beta", st.Beta);
            JObject things = new JObject();
            things.Add("thisThing", JToken.FromObject(st.ThisThing, serializer));
            things.Add("thatThing", JToken.FromObject(st.ThatThing, serializer));
            obj.Add("things", things);
            obj.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
