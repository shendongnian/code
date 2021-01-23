    JArray tokens = JArray.Parse(value);
    foreach (JToken token in tokens)
    {
        string name = token.Value<string>("name");
        DateTime theDate = DateTime.MinValue;
        DateTime.TryParse(token.Value<string>("value"), out theDate);
    }
