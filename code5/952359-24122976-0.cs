    class Program
    {
        static void Main(string[] args)
        {
            LogManager.LogFactory = new ConsoleLogFactory();
            var appHost = new AppHost();
            appHost.Init();
            appHost.Start("http://*:2001/");
            using (WebApp.Start<Startup>("http://*:2002/"))
            {
                "\n\nListening on http://*:2001/..".Print();
                "SignalR listening on http://*:2002/".Print();
                "\n\nType Ctrl+C to quit..".Print();
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration
                {
                    EnableDetailedErrors = true,
                    EnableJSONP = true
                };
                map.RunSignalR(hubConfiguration);
            });
        }
    }
