    public class AuthorizationRequiredAttribute : AuthorizeAttribute
    {
        #region Overrides of AuthorizeAttribute
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
            if (skipAuthorization) return;
            base.OnAuthorization(filterContext);
            //now look to see if this is an ajax request, and if so, we'll return a custom status code
            if (filterContext.Result == null) return;
            
            if (filterContext.Result.GetType() == typeof (HttpUnauthorizedResult) &&
                filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ContentResult();
                filterContext.HttpContext.Response.StatusCode = 403;
            }
        }
        #endregion
    }
