    public class MvcApplication : NinjectHttpApplication
    {
        /// <summary>
        /// Handles the PostAuthenticateRequest event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            // Get a PostAuthenticateRequestProvider and use this to apply a 
            // correctly configured principal to the current http request
            var provider = (IPostAuthenticateRequestProvider)
                DependencyResolver.Current.GetService(typeof(IPostAuthenticateRequestProvider));
            provider.ApplyPrincipleToHttpRequest(HttpContext.Current);
        }
    .
    .
    }
