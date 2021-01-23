    JToken token = JToken.Parse(jsonCategoryContents);
    if (token.Type == JTokenType.Object) 
    {
        JObject jsonCategoryObject = token.ToObject<JObject>();
    }
    else if (token.Type == JTokenType.Array)
    {
        JArray jsonCategoryArray = token.ToObject<JArray>();
    }
