    public static object DeserializeObject(string value, Type type, JsonSerializerSettings settings)
        {
            ValidationUtils.ArgumentNotNull(value, "value");
            JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(settings);
            // by default DeserializeObject should check for additional content
            if (!jsonSerializer.IsCheckAdditionalContentSet())
                jsonSerializer.CheckAdditionalContent = true;
            using (var reader = new JsonTextReader(new StringReader(value)))
            {
                return jsonSerializer.Deserialize(reader, type);
            }
        }
