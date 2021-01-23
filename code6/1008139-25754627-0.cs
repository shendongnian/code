    public static void Test()
    {
        var foo = new Dictionary<int, string> { { 1, "a" }, { 2, "b" }, { 3, "c" }, { 4, "d" }, { 5, "e" } };
        RemoveItemByKey(ref foo, 3);
        RemoveItemByValue(ref foo, "a");
        foreach (var kvp in foo)
        {
            Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
        }
        // Output:
        // 1: b
        // 2: d
        // 3: e
    }
    public static void RemoveItemByValue(ref Dictionary<int, string> dictionary, string valueToRemove)
    {
        foreach (var kvp in dictionary.Where(item=>item.Value.Equals(valueToRemove)).ToList())
        {
            RemoveItemByKey(ref dictionary, kvp.Key);
        }
    }
    public static void RemoveItemByKey(ref Dictionary<int, string> dictionary, int keyToRemove)
    {           
        if (dictionary.ContainsKey(keyToRemove))
        {
            dictionary.Remove(keyToRemove);
            int newIndex = 1;
            dictionary = dictionary.ToDictionary(keyValuePair => newIndex++, keyValuePair => keyValuePair.Value);
        }
    }
