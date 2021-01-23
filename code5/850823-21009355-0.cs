    static public IDictionary<int, String> GetStates()
    {
      if (states != null)
      {
        return new ReadOnlyDictionary(states);
      }
