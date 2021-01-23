    private static Dictionary<int, string> ReorderDictionary(Dictionary<int, string> originalDictionary, int newTopItem)
    {
        // Initialize ordered dictionary with new top item.
        var reorderedDictionary = new Dictionary<int, string> {{ newTopItem, originalDictionary[newTopItem] }};
        foreach (var item in originalDictionary)
        {
            if (item.Key == newTopItem)
            {
                // Skip the new top item.
                continue;
            }
            reorderedDictionary.Add(item.Key, item.Value);
        }
        return reorderedDictionary;
    }
