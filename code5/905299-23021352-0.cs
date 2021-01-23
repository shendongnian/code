    public static class NetworkLogger
    {
       public static void Violation(string message)
       {
          GenericSource.Instance.Violation("Network", message, NetworkContext.Current);
       }
    }
    
    public static class DatabaseLogger
    {
      public static void Violation(string message)
      {
          GenericSource.Instance.Violation("Database", message, DBContext.Current);
      }
    }
