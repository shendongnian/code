    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
           Scan(
                scan =>
                {
                    scan.Assembly("iFloor.Data");
                    scan.Assembly("iFloor.Logic.Domain");
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            For<ILogger>().Use(lgr).Singleton();
          }
    }
