    public class IPActionFilter : ActionFilterAttribute
    
         {
              public override void OnActionExecuting(ActionExecutingContext context)
              {
                   ViewBag.HtmlStr = "Workstation name: " + IP();
              }
    
         }
