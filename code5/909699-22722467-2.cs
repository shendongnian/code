    class DocumentConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Document));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Document doc = (Document)value;
            // Create a JObject from the document, respecting existing JSON attribs
            JObject jo = JObject.FromObject(value);
            // At this point the DocTypeIdentifier is not serialized correctly.
            // Fix it by replacing the property with the correct name and value.
            JProperty prop = jo.Children<JProperty>()
                               .Where(p => p.Name == "DocTypeIdentifier")
                               .First();
            prop.AddAfterSelf(new JProperty(doc.DocTypeIdentifier.ParameterName, 
                                            doc.DocTypeIdentifier.Value));
            prop.Remove();
            // Write out the JSON
            jo.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
