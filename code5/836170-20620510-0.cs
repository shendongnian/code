    string content = File.ReadAllText(path);
    var token = JToken.Parse(content);
    
    if (token is JArray)
    {
    }
    else if (token is JObject)
    {
        JObject jobj = token as JObject;
        Phone phone = jobj.ToObject<Phone>();
    }
