    public string Render(string text, Dictionary<string,string> placeholders)
    {
        Template template = Template.Parse(text);
        Dictionary<string, object> convertedPlaceholders =
            placeholders.ToDictionary(kvp => kvp.Key, kvp => (object) kvp.Value);
        return template.Render(Hash.FromDictionary(convertedPlaceholders));
    }
