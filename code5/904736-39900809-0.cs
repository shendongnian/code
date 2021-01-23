    public static class WCFAppBuilderExtensions
    {
        public static IAppBuilder IgnoreWCFRequests(this IAppBuilder builder)
        {
            return builder.MapWhen(context => IsWCFRequest(context), appBuilder =>
            {
                // Do nothing and allow the IIS ASP.NET pipeline to process the request
            });
        }
        private static bool IsWCFRequest(IOwinContext context)
        {
            // Determine whether the request is to a WCF endpoint
            return context.Request.Path.Value.EndsWith(".svc", StringComparison.OrdinalIgnoreCase);
        }
    }
