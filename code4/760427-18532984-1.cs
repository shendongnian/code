    List<string> keys = dict.Keys.ToList();
    for (int i = 0; i < keys.Count; i++)
    {
        var key = keys[i];
        List<TimeInterval> value;
        if (!dict.TryGetValue(key, out value))
        {
            continue;
        }
        dict.Add("NewKey", yourValue);
        keys.Add("NewKey");
    }
