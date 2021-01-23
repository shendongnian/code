    [assembly: OwinStartup(typeof(TwitterClient.Web.App_Start.Startup))]
    
    namespace TwitterClient.Web.App_Start
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {            
                app.MapSignalR();
            }
        }
    }
