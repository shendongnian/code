    public static class ResponseMiddlewareExtensions
    {
        //method name that will be used in the startup class, add additional parameter to accept middleware options if necessary
        public static void UseResponseMiddleware(this IAppBuilder app)
        {
            app.Use<ResponseMiddleware>();
        }
    }
