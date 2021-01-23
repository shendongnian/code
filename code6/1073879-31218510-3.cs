    public class ValidateMimeMultipartContent : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.UnsupportedMediaType, Messages.UnsupportedMediaType);
            }
        }
    }
