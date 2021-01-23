       public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
                //All other configurations
            }
        }
