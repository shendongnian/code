    public static class MyClassFactory
    {
      public static MyClass CreateWithDefaultServices()
      {
        return new MyClass(/*...*/);
      }
      public static MyClass Create(ISomeService serviceA, ISomeOtherService serviceB)
      {
        return new MyClass(serviceA, serviceB);
      }
      public static MyClass Create()
      {
        return new MyClass();
      }
      //...
    }
