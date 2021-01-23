    public class MyService 
    {
      private readonly IBaseService<SomeBaseIdentity> _service;
    
      public MyService(IBaseService<SomeBaseIdentity> service)
      {
        _service = service;
      }
    
      //.... methods that use _service
    }
