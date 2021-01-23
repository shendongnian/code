    public class MyTestController : Controller
    {	
    	[HttpPost]
    	public ActionResult ShowResult()
    	{
    		MyModel model = new MyModel();
    		model.Transform();
    		ViewBag.DecodedOutputMessage = HttpUtility.HtmlDecode(model.EncodedOutputMessage);
    		return View("MyView");
    	}
    }
