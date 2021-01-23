    public class UserAccessCheckAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.Controller as BaseApiController;
            object requestUserIdObj;
            if (controller != null && actionContext.ActionArguments.TryGetValue("userId", out requestUserIdObj))
            {
                var userId = (int) requestUserIdObj;
                if (userId != controller._current.UserId)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Unauthorized");
                }
            }
        }
    }
