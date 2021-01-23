      public static bool HasMethod(this object objectToCheck, string methodName)
      {
         BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
         var type = objectToCheck.GetType();
         return type.GetMethod(methodName, flags) != null;
      } 
