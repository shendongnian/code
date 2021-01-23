    private static IEnumerable<Type> MyTypes
    {
      get
      {
        //Return concrete types, NOT interfaces
        yield return typeof(MyType<Arg1>);
        yield return typeof(MyType<Arg2>);
        //...
      }
    }
    public override void Initialize()
    {
      base.Initialize();
      MyTypes.AsInterfaces().RegisterAsLazySingleton();
    }
