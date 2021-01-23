        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (Thread.CurrentPrincipal.Identity.Name.Length == 0)
            {
                // If using Basic Authentication, do that here
            }
            if (Thread.CurrentPrincipal.Identity.Name.Length == 0)
            {
                var response = HttpContext.Current.Response;
                response.SuppressFormsAuthenticationRedirect = true;
                response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                response.End();
            }
            return base.IsAuthorized(actionContext);
        }
