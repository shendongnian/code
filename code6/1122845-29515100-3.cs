    public int GetMyItem(string key)
    {
       if (string.IsNullOrEmpty(key)) throw new ArgumentNullException("key");
       if (!_myDictionary.ContainsKey(key))
       {
          throw new KeyNotFoundException();
       }
       // Additional implementation left out
    }
