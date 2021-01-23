    public class MyAPIAuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //perform check here, perhaps against AD group, or check a roles based db?
            if(success)
            {
                base.OnActionExecuting(actionContext);
            }
            else
            {
                var msg = string.Format("User {0} attempted to use {1} but is not a member of the AD group.", id, actionContext.Request.Method);
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent(msg),
                    ReasonPhrase = msg
                });
            }
        }
    }
