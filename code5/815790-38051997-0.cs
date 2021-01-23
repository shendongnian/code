        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = "_Logon_",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized; 
                filterContext.HttpContext.Response.SuppressFormsAuthenticationRedirect = true;
            }
