    public class Greeter
    {
      private readonly IFooFactory _fooFactory;
    
      public Greeter(IFooFactory fooFactory)
      {
        _fooFactory = fooFactory;
      }
    
      public string SayHelloWithABar(IBar bar)
      {
        IFoo foo = _fooFactory.CreateFoo(bar);
    
        // do something with your 'foo' instance ...
        return "hello!";
      }
    }
