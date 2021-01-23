    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
        if (ReferenceEquals(value, null)) {
            writer.WriteNull();
            return;
        }
                
        var contract = (JsonObjectContract)serializer
            .ContractResolver
            .ResolveContract(value.GetType());
                
        writer.WriteStartObject();
        
        foreach (var property in contract.Properties) {
            if (property.Ignored) continue;
            if (!ShouldSerialize(property, value)) continue;
    
            var property_name = property.PropertyName;
            var property_value = property.ValueProvider.GetValue(value);
            
            writer.WritePropertyName(property_name);
            if (property.Converter != null && property.Converter.CanWrite) {
                property.Converter.WriteJson(writer, property_value, serializer);
            } else {
                serializer.Serialize(writer, property_value);
            }
        }
        
        writer.WriteEndObject();
    }
    
    private static bool ShouldSerialize(JsonProperty property, object instance) {
        return property.ShouldSerialize == null 
            || property.ShouldSerialize(instance);
    }
