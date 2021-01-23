    private MyTypeCodes() { }
    private static MyTypeCodes _instance = new MyTypeCodes();
    public static DoSomethingWithType()
    {
      return _instance.GetType().foo();
    }
