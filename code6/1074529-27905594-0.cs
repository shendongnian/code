    public static class FooExtensions {
      public static void DoSomething(this IFoo value) {
        FooBase special = value as FooBase;
    
        if (null != special)
          special.SomeMethod();
      }
    }
    
    public class Bar
    {
      public void DoSomething(IFoo foo)
      {
        // Extension is called
        foo.SomeMethod();
      }
    }
