    public static void UseOwinContextInjector(this IAppBuilder app, Container container)
    {
    // Create an OWIN middleware to create an execution context scope
    app.Use(async (context, next) =>
    {
         using (var scope = container.BeginExecutionContextScope())
         {
             await next.Invoke();
         }
    });
    }
