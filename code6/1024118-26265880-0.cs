    public class ValidateRequestAttribute : ActionFilterAttribute
    {
       public override void OnActionExecuting(HttpActionContext actionContext)
       {
          if (!actionContext.ModelState.IsValid)
          {
             actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState)
          }
       }
    }
