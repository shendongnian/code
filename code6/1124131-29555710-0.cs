    protected override void HandleUnauthorizedRequest(AuthorizationContext context)
    {
        if (context.HttpContext.Request.IsAjaxRequest()) {
            dynamic urlHelper = new UrlHelper(context.RequestContext);
            context.HttpContext.Response.TrySkipIisCustomErrors= true;
            context.HttpContext.Response.StatusCode = 403;
            context.Result = new JsonResult {
                Data = new {
                    Error = "NotAuthorized",
                    LogOnUrl = urlHelper.Action("Registration", "Membership")
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        } else {
            base.HandleUnauthorizedRequest(context);
        }
    }
