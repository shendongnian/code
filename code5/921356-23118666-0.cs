    if (reader.TokenType == JsonToken.StartArray)
    {
        var values = serializer.Deserialize<List<Dictionary<string, JToken>>>(reader);
        objectContainer = ClassifyAndReturn(values); 
    }
    private ObjectType ClassifyAndReturn(List<Dictionary<string, JToken>> values)
    {
        if (values.First().ContainsKey("self"))
        {
            string self = values.First()["self"].Value<string>();
            if (self.Contains("customFieldOption"))
            //... Then go into a series of if else cases to determine the object. 
