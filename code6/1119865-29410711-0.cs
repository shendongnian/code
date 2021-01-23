        /// <summary>
        /// Application_s the post authorize request.
        /// </summary>
        protected void Application_PostAuthorizeRequest()
        {
            if (HttpContext.Current.Request.FilePath.StartsWith("/sessionapi"))
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }
