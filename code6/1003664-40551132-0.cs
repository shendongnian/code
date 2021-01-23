    var options = new StartOptions();
    options.Settings["Microsoft.Owin.Hosting.Builder.IAppBuilderFactory"] = "MyNamespace.MyAppBuilderFactory,My.Assembly.Name";
    var webServer = Microsoft.Owin.Hosting.WebApp.Start(options);
    public class MyAppBuilderFactory : IAppBuilderFactory
    {
        public IAppBuilder Create()
        {
            return new MyAppBuilder();
        }
    }
