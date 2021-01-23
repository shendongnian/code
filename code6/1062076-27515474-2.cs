    public class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            //  Enable attribute based routing
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        
        }
    }
