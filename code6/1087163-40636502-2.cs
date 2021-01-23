    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Add claims transformation using <see cref="ClaimsTransformationMiddleware" /> any depdendency resolution is done via IoC
        /// </summary>
        /// <param name="app"></param>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static IAppBuilder UseClaimsTransformation(this IAppBuilder app, IServiceProvider serviceProvider)
        {
            app.Use<ClaimsTransformationMiddleware>(serviceProvider);
            return app;
        }
    }
