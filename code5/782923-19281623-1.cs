    public class HomeController : BaseController
    {
    	public ActionResult ActionX()
    	{
    		// Creates a new MyVM.
    		MyVM myVm = PrepareViewModel();		
    	}
    	
    	public ActionResult ActionY()
    	{
    		// Update an existing MyVM object.
    		var myVm = new MyVM
    					   {
    						   Property1 = "Value 1",
    						   Property2 = DateTime.Now
    					   };
    		PrepareViewModel(myVm);
    	}
    }
