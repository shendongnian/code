    public abstract class MyAbstractController : Controller
    {
    	public MyAbstractController()
    	{
    		SubDomain = new SubDomainProvider();
    	}
    
    	protected string SubDomain {get; set; }
    }
	public class SomeController : MyAbstractController
	{
		public ActionResult SomeAction()
		{
			// access the subdomain by calling the base base.SubDomain 
		}
	}
