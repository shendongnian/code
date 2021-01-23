    private static string _k;
    public static string k
    {
      get {
        return _k;
      }
      set {
        _k = value
        CollectMethod(value);
      }
    }
