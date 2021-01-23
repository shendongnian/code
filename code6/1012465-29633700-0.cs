        public class NoSlash : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
                var originalUrl = filterContext.HttpContext.Request.Url.ToString();
                var newUrl = originalUrl.TrimEnd('/');
                if (originalUrl.Length != newUrl.Length)
                    filterContext.HttpContext.Response.Redirect(newUrl);
            }
        }
