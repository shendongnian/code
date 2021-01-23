    // have several handler classes
    class FooMessageHandler : IMessageHandler<Foo>
    {  }
    
    class BarMessageHandler : IMessageHandler<Bar>
    {  }
    
    // have them instantiated - allows you to pass much more context
    // than Activator.CreateInstance is able to do    
    var fooMessageHandler = new FooMessageHandler(various params);
    var barMessageHandler = new BarMessageHandler(various params);
    
    // register actual instances    
    HandlerRegistry.Register<Foo>(fooMessageHandler);
    HandlerRegistry.Register<Bar>(barMessageHandler);
    
    // handler registry will simply dispatch the message to
    // one of the handlers        
    HandlerRegistry.Dispatch(someFooMessage);
