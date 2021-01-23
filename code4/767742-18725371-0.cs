    //I know this isn't the real type of your input; 
    //modify the parameter to be of the actual type of your collection of pairs
    //TODO come up with better name for this function
    public static dynamic Foo(IEnumerable<KeyValuePair<string,string>> pairs)
    {
        IDictionary<string, object> result = new ExpandoObject();
        foreach (var pair in pairs)
            result.Add(pair.Key, pair.Value);
        return result;
    }
