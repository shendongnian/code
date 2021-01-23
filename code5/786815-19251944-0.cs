    private Dictionary<String, Int32> dictionary = ...
    public IEnumerable<Int32> Dictionary { get{ return dictionary.Values; } }
    // Other methods in the class can still access the 'dictionary' (lowercase).
    // But external users can only see 'Dictionary' (uppercase).
    void AddItemToDictoinary(String key, Int32 value) {
        dictionary.Add(key, value);  // dictionary is accessible within the class.
    }
