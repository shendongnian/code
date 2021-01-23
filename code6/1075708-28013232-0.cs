        using Microsoft.AspNet.SignalR;
        using Microsoft.Owin.Cors;
        using Owin;
        public partial class Startup {
        public void Configuration(IAppBuilder app)
        {
            // map signalr hubs
            app.Map("/city", map => {
                                 map.UseCors(CorsOptions.AllowAll);
                                 var config = new HubConfiguration() {
                                     EnableJSONP = true,
                                     EnableJavaScriptProxies = false
                                 };
                                 config.EnableDetailedErrors = true;
                                 map.RunSignalR(config);
                             });
            ConfigureAuth(app);
        }
    }
