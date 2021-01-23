    public class IncludeCultureCodesAttribute : ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		var controller = filterContext.Controller;
    
    		// IController is not necessarily a Controller
    		if (controller != null)
    		{
    			var db = new YourContext();
    			controller.ViewBag.Codes = new SelectList(db.CultureCodes, "ID", "DisplayName"));;
    		}
    	}
    }
