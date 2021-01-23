    public class ValidateModelAttribute : ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                  if (!filterContext.Controller.ViewData.ModelState.IsValid)
                  {
                       filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
                  }
            }
    }
