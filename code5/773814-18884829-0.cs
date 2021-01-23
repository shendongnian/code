    public class WrappedUatService : IService {
       private Domain.Uat.Service _service;
       
       public override ILoginResult Login() { 
           ILoginResult result = new WrappedLoginResult(_service.Login());
           ...
       }
    }
    public class WrappedProdService : IService {
       private Domain.Prod.Service _service;
       
       public override ILoginResult Login() { 
           ILoginResult result = new WrappedLoginResult(_service.Login());
           ...
       }
    }
