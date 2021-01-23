        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (string.IsNullOrWhiteSpace(Thread.CurrentPrincipal.Identity.Name))
            {
                var response = HttpContext.Current.Response;
                response.SuppressFormsAuthenticationRedirect = true;
                response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                response.End();
            }
            return base.IsAuthorized(actionContext);
        }
