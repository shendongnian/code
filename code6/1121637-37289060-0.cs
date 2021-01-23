    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseApplicationInsights();
            // rest of the config here...
        }
    }
