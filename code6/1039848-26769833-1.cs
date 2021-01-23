    public class WebPipeline
    {
        public static void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            MyWebApi.Service.Register(config);
            MyWebApi.Service.OnStartup();
            app.UseWebApi(config);
        }
        public static void Shutdown()
        {
            MyWebApi.Service.OnShutdown();
        }
    }
