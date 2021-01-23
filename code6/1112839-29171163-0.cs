    jsonText = jsonText.Trim();
    
    // If your JSON string starts with [, it's an array...
    if(jsonText.StartsWith("["))
    {
        var array = JsonConvert.DeserializeObject<IEnumerable<string>>(jsonText);
    }
    else // Otherwise, it's an object...
    {
        var someObject = JsonConvert.DeserializeObject<YourClass>(jsonText);
    }
