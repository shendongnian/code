    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Do request-scoped registrations using InstancePerRequest...
            var container = builder.Build();
            // Pass the pre-built container to the bootstrapper
            var bootstrapper = new MyAwesomeNancyBootstrapper(container);
            app.UseNancy(options => options.Bootstrapper = bootstrapper);
        }
    }
