    interface IMyFace
    {
      void MethodToTest(object obj);
    }
    static class Test
    {
      public static void Main()
      {
        Setup<IMyFace>(x => x.MethodToTest(null));
        Setup<IMyFace>(x => x.MethodToTest(MyAnyA<object>()));
        Setup<IMyFace>(x => x.MethodToTest(MyAnyB<object>()));
      }
      public static TArg MyAnyA<TArg>()
      {
        // never runs
        return default(TArg);
      }
      public static TArg MyAnyB<TArg>()
      {
        // never runs
        return default(TArg);
      }
      public static void Setup<T>(Expression<Action<T>> expr) where T : class
      {
        Console.WriteLine("The expr was: " + expr);
      }
    }
