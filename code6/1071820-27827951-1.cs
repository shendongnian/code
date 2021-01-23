    class OmitPropertiesConverter : JsonConverter
    {
        string[] propsToOmit;
        public OmitPropertiesConverter(string propsToOmit)
        {
            this.propsToOmit = propsToOmit.Split(new char[] {','},
                                                 StringSplitOptions.RemoveEmptyEntries);
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(SharedClass));
        }
        public override void WriteJson(JsonWriter writer, object value, 
                                       JsonSerializer serializer)
        {
            JObject jo = JObject.FromObject(value, serializer);
            // Note: ToList() is needed here to prevent "collection was modified" error
            foreach (JProperty prop in jo.Properties()
                                         .Where(p => propsToOmit.Contains(p.Name))
                                         .ToList())
            {
                prop.Remove();
            }
            jo.WriteTo(writer);
        }
        public override bool CanRead
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType,
                                        object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
