    public static T? TryParseJson<T>(this string json, string schema) where T : new()
    {
      JsonSchema parsedSchema = JsonSchema.Parse(schema);
      JObject jObject = JObject.Parse(json);
      if (!jObject.IsValid(parsedSchema))
      {
         return default(T);
      }
      return (T)JsonConvert.DeserializeObject(json);
    } 
