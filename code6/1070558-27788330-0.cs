    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            GlobalHost.Configuration.DisconnectTimeout = new TimeSpan(0, 0, 20);
        }
    }
