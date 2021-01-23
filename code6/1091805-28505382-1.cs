    // composite service - you have to implement this interface
    public interface ICommonServices
    {
         IServiceA ServiceA { get; }
         IServiceB ServiceB { get; }
    }
    // constructor of your component
    public MyComponent(ICommonServices services)
    {
        _services = services;
    }
    // method of your component
    public void SomeMethod()
    {
        _services.ServiceA.DoSomething();
    }
