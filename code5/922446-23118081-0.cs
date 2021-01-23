    public class MyBootstrapper : DefaultNancyBootstrapper
    {
    #if DEBUG
        protected override IRootPathProvider RootPathProvider
        {
            get
            {
                // this sets the root folder to the VS project directory
                // so that any template updates in VS will be picked up
                return new MyPathProvider();
            }
        }
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(
                    x =>
                        { x.ViewCache = typeof(MyViewCache); });
            }
        }
    #endif
