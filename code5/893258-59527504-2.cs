    public class ValidateHeaderAntiForgeryAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string cookieToken = "";
            string formToken = "";
            if (filterContext.HttpContext.Request.Headers["RequestVerificationToken"] != null)
            {
                string[] tokens = filterContext.HttpContext.Request.Headers["RequestVerificationToken"].Split(':');
                if (tokens.Length == 2)
                {
                    cookieToken = tokens[0].Trim();
                    formToken = tokens[1].Trim();
                }
            }
            try
            {
                AntiForgery.Validate(cookieToken, formToken);
                base.OnActionExecuting(filterContext);
            }
            catch
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
