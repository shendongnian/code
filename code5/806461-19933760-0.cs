        protected void Application_BeginRequest()
        {
            HttpRequestBase request = new HttpRequestWrapper(Context.Request);
            if (request.IsAjaxRequest())
            {
                Context.Response.SuppressFormsAuthenticationRedirect = true;
            }
        }
