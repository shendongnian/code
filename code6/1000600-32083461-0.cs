    public class BaseTest() 
    {
        private const string baseUrl = "http://mywebsite.web:9999";
        private static readonly AsyncLazy<HttpSelfHostServer> server = new AsyncLazy<HttpSelfHostServer>(async () =>
        {
            try
            {
                Log.Information("Starting web server");
                
                var config = new HttpSelfHostConfiguration(baseUrl);
                new Startup()
                    .Using(config)
                    .Add.AttributeRoutes()
                    .Add.DefaultRoutes()
                    .Remove.XmlFormatter()
                    .Serilog()
                    .Autofac()
                    .EnsureInitialized();
                var server = new HttpSelfHostServer(config);
                await server.OpenAsync();
                Log.Information("Web server started: {0}", baseUrl);
                return server;
            }
            catch (Exception e)
            {
                Log.Error(e, "Unable to start web server");
                throw;
            }
        });
        public BaseTest() 
        {
            server.Start()
        }
    }
