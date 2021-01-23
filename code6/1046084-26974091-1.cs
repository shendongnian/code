    public class SomeController : Controller
    {
    	private readonly ISubDomainProvider _subDomainProvider;
    	public SomeController()
    	{
    		_subDomainProvider = new SubDomainProvider();
    	}
    } 
