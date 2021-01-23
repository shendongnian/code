        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var key = filterContext.HttpContext.Request.QueryString["downloading"].ToString();
            if (key != null)
            {
                var cookie = new HttpCookie(key);
                cookie.Path = "/";
                filterContext.HttpContext.Response.Cookies.Add(cookie);
            }
        }
