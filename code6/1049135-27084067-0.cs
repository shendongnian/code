        using System.Web.Http.Controllers;
        using System.Web.Http.Filters;
        public class UserFilter : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                        // Properties is part of the Request here, you can access it
                        // actionContext.Request.Properties
            }
        }
