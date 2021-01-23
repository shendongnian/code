    private readonly Object lockobj = new Object();
    
    static void ProcessConcat(Dictionary<string, BarClass> _myDictionary, string key, BarClass value)
    {
        lock(lockobj)
        {
         if (!_myDictionary.ContainsKey(key))
              _myDictionary.Add(key, value)
        }
    }
