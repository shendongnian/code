    Dictionary<string, string> result = new Dictionary<string, string>();
    foreach (var keyVal in orig)
    {
        if (!string.IsNullOrEmpty(keyVal.Value))
            result.Add(keyVal.Key, keyVal.Value);
        else
        {
            string val2;
            if (newDict.TryGetValue(keyVal.Key, out val2))
                result.Add(keyVal.Key, val2);
            else
                result.Add(keyVal.Key, "");
        }
    }
