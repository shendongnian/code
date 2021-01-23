    // The main dictionary
    var dict = new Dictionary<string, List<TimeInterval>>();
    // The temporary dictionary where new keys are added
    var next = new Dictionary<string, List<TimeInterval>>();
    // current will contain dict or the various instances of next
    // (multiple new Dictionary<string, List<TimeInterval>>(); can 
    // be created)
    var current = dict;
    while (true)
    {
        foreach (var kv in current)
        {
            // if necessary
            List<TimeInterval> value = null;
            // We add items only to next, that will be processed
            // in the next while (true) cycle
            next.Add("NewKey", value);
        }
        if (next.Count == 0)
        {
            // Nothing was added in this cycle, we have finished
            break;
        }
        foreach (var kv in next)
        {
            dict.Add(kv.Key, kv.Value);
        }
        current = next;
        next = new Dictionary<string, List<TimeInterval>>();
    }
