    class Sqm
    {
      private static List<List<Value>> = _lists = new List<List<Value>>();
      private static List<List<Value>> = _finalizationQueue = new List<List<Value>>();
      private List<Value> _values = new List<Value>();
      Sqm() { _lists.Add(_values); }
      ~Sqm() { _finalizationQueue.Add(_values); }
      public static void CheckAndSave()
      {
        foreach(var list in _finalizationQueue)
          SaveValues(list);
      }
    }
