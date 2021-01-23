    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            GlobalHost.Configuration.MaxIncomingWebSocketMessageSize = 2048576;
        }
    }
