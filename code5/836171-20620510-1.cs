    string content = File.ReadAllText(path);
    var token = JToken.Parse(content);
    
    if (token is JArray)
    {
        IEnumerable<Phone> phones = token.ToObject<List<Phone>>();
    }
    else if (token is JObject)
    {
        Phone phone = token.ToObject<Phone>();
    }
