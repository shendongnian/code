    public static class UserContext
    {
      [ThreadStatic]
      public static string Username;
    }
