    public static IList<Foo> FooList(IFooService fooService)
    {
      //some change to the application has meant this is no longer safe to cache, but
      //we only needed to change one piece of code:
      return fooService.GetFoos();
    }
