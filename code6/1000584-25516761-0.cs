    public class PayPal : Controller
    {
    	[HttpGet]
    	public ActionResult RedirectFromPaypal(string type)
    	{
            // PayPal calls this action on order completion.
            // I made "type" a string for this example but it can be anything.
            // Add other parameters as needed.
            // Processing, etc.
    		return View();
    	}
    }
