    public class ValidateModelAttribute : ActionFilterAttribute
    {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                  if (filterContext.Controller.ViewData.ModelState.IsValid == false)
                  {
                       filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);  
                  }
            }
    }
