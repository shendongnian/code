    public class CommonController : Controller
    {
    	public ActionResult LoginForm()
    	{
    		var model = new LoginModel();
    		return PartialView("_LoginPartial", model);
    	}
    }
