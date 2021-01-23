    private Dictionary<String, Int32> dictionary = ...
    public Int32 this[String key] { get { return dictionary[key]; } }
    // Same as above - within the class you can still add items to the dictionary.
    void AddItemToDictoinary(String key, Int32 value) {
        dictionary.Add(key, value);
    }
