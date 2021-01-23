    public class ApplicationStartup : ApplicationEventHandler
    {
        internal static IWindsorContainer Container;
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarting(umbracoApplication, applicationContext);
            Container = new WindsorContainer()
                .Install(Configuration.FromAppConfig())
                .Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
            
            FilteredControllerFactoriesResolver.Current.InsertType<FilteredControllerFactory>(0);
        }
    }
