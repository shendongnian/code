        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("_custom_Prop_");
            writer.WriteValue("Custom Property value");
            WriteObjectProperties(writer, value);
            writer.WriteEndObject();
        }
        private static void WriteObjectProperties(JsonWriter writer, object value)
        {
            var myJsonWriter = new JTokenWriter();
            var js = new JsonSerializer();
            js.ContractResolver = new CamelCasePropertyNamesContractResolver();
            js.Serialize(myJsonWriter, value);
            var childTokens = myJsonWriter.Token.Children();
            foreach (var childToken in childTokens)
            {
                childToken.WriteTo(writer);
            }
        }
