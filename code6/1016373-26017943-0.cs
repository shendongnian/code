    Dictionary<string, object> myDictionary = new Dictionary<string, object>();
    
    foreach (JObject content in jarray.Children<JObject>())
    {
        foreach (JProperty prop in content.Properties())
        {
            myDictionary.Add(prop.Name, prop.Value);
        }
    }
