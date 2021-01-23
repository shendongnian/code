    class MyAttribute : HandlerAttribute
    {
       override ICallHandler CreateHandler(IUnityContainer container)
       {
           return new TestCallHandler();
       }
    }
    Interface IFoo
    {
       [MyAttribute]
       void AMethod();
    }
