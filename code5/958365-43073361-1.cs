    public class DefaultRegistry : Registry
    {
        var lgr = new Logger("filepath or whatever...");
        public DefaultRegistry()
        {
           Scan(
                scan =>
                {
                    scan.Assembly("YourApp.Data");
                    scan.Assembly("YourApp.Domain");
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            For<ILogger>().Use(lgr).Singleton();
          }
    }
