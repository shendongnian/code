    public void MyMethod(string a) 
    {
      if (!dictionary.ContainsKey(a))
      {
        lock (dictionary)
        {
          if (!dictionary.ContainsKey(a))
          {
            dictionary.Add(a, "someothervalue");
          }
        }
      }
    }
