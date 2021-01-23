    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JProperty typeHintProperty = TypeHintPropertyForType(value.GetType());
        JObject jo = new JObject();
        if (typeHintProperty != null)
        {
            jo.Add(typeHintProperty);
        }
        foreach (PropertyInfo prop in value.GetType().GetProperties())
        {
            if (prop.CanRead)
            {
                object propValue = prop.GetValue(value);
                if (propValue != null)
                {
                    jo.Add(prop.Name, JToken.FromObject(propValue, serializer));
                }
            }
        }
        jo.WriteTo(writer);
    }
