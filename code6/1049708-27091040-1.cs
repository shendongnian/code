    public enum Enum1 
    {
      A, B
    }
    public enum Enum2
    {
      C, D
    }
    public static class EnumBrowser
    {
      public static IEnumerable<T> GetValues<T>()
      {
        if (!typeof(T).IsEnum) 
          throw new ArgumentException("T must be an enumerated type");
        return Enum.GetValues(typeof(T)).Cast<T>();
      }
      public static void PrintValues<T>(IEnumerable<T> values)
      {
        foreach (var value in values)
    	  Console.WriteLine(value.ToString());
      }
    }
    
    public void Main()
    {
      EnumBrowser.PrintValues(EnumBrowser.GetValues<Enum1>()); // A B
      EnumBrowser.PrintValues(EnumBrowser.GetValues<Enum2>()); // C D
    }
