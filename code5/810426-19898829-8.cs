    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Form f = (Form)value;
        JObject jo = new JObject();
        if (serializedForms.Add(f))
        {
            foreach (PropertyInfo prop in value.GetType().GetProperties())
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(value);
                    if (propVal != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
        }
        else
        {
            jo.Add("Id", f.Id);
        }
        jo.WriteTo(writer);
    }
