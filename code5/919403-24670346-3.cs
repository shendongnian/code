    public class UmbracoStartupHandler : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(FixedAsyncRenderMvcController));
            FilteredControllerFactoriesResolver.Current.RemoveType<RenderControllerFactory>();
            FilteredControllerFactoriesResolver.Current.AddType<FixedAsyncRenderControllerFactory>();
            
            base.ApplicationStarting(umbracoApplication, applicationContext);
        }
    }
