    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JObject jo = new JObject();
        Type type = value.GetType();
        jo.Add("type", type.Name);
        foreach (PropertyInfo prop in type.GetProperties())
        {
            if (prop.CanRead)
            {
                object propVal = prop.GetValue(value, null);
                if (propVal != null)
                {
                    jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                }
            }
        }
        jo.WriteTo(writer);
    }
