    class Z {
      public static string[] alfaromeo = new string[] {"lots of stuff"};
    }
    // ...
    typeof(Z).GetField("alfaromeo", BindingFlags.Static | BindingFlags.Public).GetValue(null);
