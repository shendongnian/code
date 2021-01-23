    IDictionary<ClearAttributes,string> collection = new Dictionary<ClearAttributes, string>();
    collection.Add(ClearAttributes.S_DURATION, "SomeText1");
    collection.Add(ClearAttributes.S_TYPE, "SomeText2");
    string value = string.Empty;
    collection.TryGetValue(ClearAttributes.S_DURATION, out value);
