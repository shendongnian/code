    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        MethodInfo parse = objectType.GetMethod("Parse", new Type[] { typeof(string) });
        if (parse != null && parse.IsStatic && parse.ReturnType == objectType)
        {
            return parse.Invoke(null, new object[] { (string)reader.Value });
        }
        throw new JsonException(string.Format(
            "The {0} type does not have a public static Parse(string) method that returns a {0}.", 
            objectType.Name));
    }
