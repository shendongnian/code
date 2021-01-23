    public static class SessionInformation
    {
      private static bool hasBeenSet = false;
    
      public static string UserName { get; private set; }
    
      public static void SetValues(string userName)
      {
        if (hasBeenSet) return;
    
        UserName = userName;
        hasBeenSet = true;
      }
    }
