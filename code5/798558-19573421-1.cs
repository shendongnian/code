    public void MyMethod(string a) 
    {
      // The variable 'dictionary' is a ConcurrentDictionary.
      dictionary.GetOrAdd(a, "someothervalue");
    }
