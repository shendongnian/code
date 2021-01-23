    public static void RequireAspNetSession(IAppBuilder app)
    {
        app.Use((context, next) =>
        {
            var httpContext = context.Get<HttpContextBase>(typeof(HttpContextBase).FullName);
            httpContext.SetSessionStateBehavior(SessionStateBehavior.Required);
            return next();
        });
        // To make sure the above `Use` is in the correct position:
        app.UseStageMarker(PipelineStage.MapHandler);
    }
