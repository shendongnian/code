    /// <summary>
    /// Middleware component to apply claims transformation to current context
    /// </summary>
    public class ClaimsTransformationMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> next;
        private readonly IServiceProvider serviceProvider;
        public ClaimsTransformationMiddleware(Func<IDictionary<string, object>, Task> next, IServiceProvider serviceProvider)
        {
            this.next = next;
            this.serviceProvider = serviceProvider;
        }
        public async Task Invoke(IDictionary<string, object> env)
        {
            // Use Katana's OWIN abstractions
            var context = new OwinContext(env);
            if (context.Authentication != null && context.Authentication.User != null)
            {
                var manager = serviceProvider.GetService<ClaimsAuthenticationManager>();
                context.Authentication.User = manager.Authenticate(context.Request.Uri.AbsoluteUri, context.Authentication.User);
            }
            await next(env);
        }
    }
