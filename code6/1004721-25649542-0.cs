    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value == null || !(value is ParentObject))
            return;
        var pObject = (ParentObject) value;
        writer.WriteStartObject();
        writer.WritePropertyName("Prop1");
        writer.WriteValue(pObject.Prop1);
        writer.WritePropertyName("Prop2");
        writer.WriteValue(pObject.Prop2);
        foreach (var info in pObject.AdditionalInformation)
        {
            JObject jObj = JObject.FromObject(info);
            foreach (var property in jObj.Properties())
            {
                writer.WritePropertyName(property.Name);
                writer.WriteValue(property.Value);
            }
        }
        writer.WriteEndObject();
    }
