    public static Object setObjectProperty(Dictionary<String, String> dictionary)
    {
        IDictionary<string, object> newObj = new ExpandoObject();
        foreach (var word in dictionary)
        {
            newObj.Add(word.Key, word.Value);
        }
        return newObj;
    }
