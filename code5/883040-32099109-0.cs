    public class BaseController : Controller
    {
        protected ISomeType SomeMember { get; set; }
        public BaseController(IServiceProvider serveiceProvider)
        {
            //Init all properties you need
            SomeMember = (SomeMember)serveiceProvider.GetService(typeof(ISomeMember));
        }
	}
	   
    public class MyController : BaseController	
    {
    public MyController(/*Any other injections goes here*/, 
                          IServiceProvider serveiceProvider) : 
     base(provider)
	{}
    }
