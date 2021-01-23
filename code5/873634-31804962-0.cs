    public class HomeController
    {
        private readonly Func<string,IService> _serviceFactory;
        
        public HomeController(Func<string, IService> serviceFactory)
        {
            if(serviceFactory==null)
                throw new ArgumentNullException("serviceFactory");
            this._serviceFactory= serviceFactory;
        }
        public void DoSomethingWithTheService()
        {
            var domain = this.HttpContext.Uri.Host;                             
		    var service = this._serviceFactory(domain);
            var greeting = service.Hello;
        }
    }
This is then still unit testable and you have not leaked the DI contain implementation outside of "composition root".
Also.. should CoreService be abstract to avoid direct instantiation of it?
