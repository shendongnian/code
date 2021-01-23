    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); // <-- this
            app.MapSignalR();
        }
    }
