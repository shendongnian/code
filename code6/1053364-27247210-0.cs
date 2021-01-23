    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/app", spa =>
            {
                spa.Use((context, next) =>
                {
                    context.Request.Path = new PathString("/index.html");
                    return next();
                });
                spa.UseStaticFiles();
            });
            app.UseWelcomePage();
        }
    }
