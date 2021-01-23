    public class Startup {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            //.... code
            app.UseIdentity();
            //... more code
            app.Use(next => {
                return async context => {
                    var httpContext = (context as HttpContext);
                    if (httpContext.User.Identity.IsAuthenticated)
                    {
                        Thread.SetData(Thread.GetNamedDataSlot("current-username"), httpContext.User.Identity.Name);
                    }
                    await next(context);
                };
            });
            //... more code
            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action}/{id?}",
                        defaults: new { controller = "Home", action = "Index" });
                });
        }
    }
