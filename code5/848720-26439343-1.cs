    class MyAttribute : HandlerAttribute
    {
       override ICallHandler CreateHandler(IUnityContainer container)
       {
           return new MyHandler();
       }
    }
    Interface IFoo
    {
       [MyAttribute]
       void AMethod();
    }
