    public class BaseController : Controller
    {
        protected ISomeType SomeMember { get; set; }
        public BaseController(IServiceProvider serviceProvider)
        {
            //Init all properties you need
            SomeMember = (SomeMember)serviceProvider.GetService(typeof(ISomeMember));
        }
	}
	   
    public class MyController : BaseController	
    {
    public MyController(/*Any other injections goes here*/, 
                          IServiceProvider serviceProvider) : 
     base(serviceProvider)
	{}
    }
