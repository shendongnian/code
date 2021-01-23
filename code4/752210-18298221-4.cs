    public static class MyClassFactory
    {
    //Just an example, but in general not really recommended.
    //May be acceptable for simple projects, but for large ones
    //remembering what does "Default" mean is an unnecessary burden
    //and it somehow reduces readability.
      public static MyClass CreateWithDefaultServices()      
      {
        return new MyClass(/*...*/);
      }
      public static MyClass Create(ISomeService serviceA, ISomeOtherService serviceB)
      {
        return new MyClass(serviceA, serviceB);
      }
      public static MyClass CreateEmpty()
      {
        return new MyClass();
      }
      //...
    }
