        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonObjectContract contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
            writer.WriteStartObject();
            foreach (var property in contract.Properties)
            {
                if (property.Ignored)
                    continue;
                writer.WritePropertyName(property.PropertyName);
                writer.WriteValue(property.ValueProvider.GetValue(value));
            }
            writer.WriteEndObject();
        }
