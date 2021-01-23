    private static object kLock = new object();
    private static string _k;
    public static string k
    {
      get {
        lock (kLock)
        {
          return _k;
        }
      }
      set {
        lock (kLock)
        {
          _k = value;
        }
       
        CollectMethod(value);
      }
    }
