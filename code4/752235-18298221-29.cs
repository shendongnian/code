    public static MyClassTestExtensions
    {
      public static MyClass WithService(
          this MyClass @this,
          ISomeService service)
      {
        @this.SomeService = service; //or something like this
        return @this;
      }
      
      public static MyClass WithOtherService(
          this MyClass @this,
          ISomeOtherService service)
      {
        @this.SomeOtherService = service; //or something like this
        return @this;
      }
    }
