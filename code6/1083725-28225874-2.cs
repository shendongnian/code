    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                map.RunSignalR(new HubConfiguration { EnableJSONP = true });
            });
        }
    }
----------
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // your client localhost
            config.EnableCors(new EnableCorsAttribute(origins: "http://localhost:4434", headers: "*", methods: "*"));
        }
    }
