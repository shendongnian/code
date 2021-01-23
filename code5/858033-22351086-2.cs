    using Autofac;
    using Autofac.Core;
    using Autofac.Integration.Web;
    using ....
    
    
    namespace MyCompany.WebForms
    { 
        public partial class Global : HttpApplication, IContainerProviderAccessor
        {
            // Provider that holds the application container.
            static IContainerProvider _containerProvider;
    
            // Instance property that will be used by Autofac HttpModules
            // to resolve and inject dependencies.
            public IContainerProvider ContainerProvider
            {
                get { return _containerProvider; }
            }
    
            protected void Application_Start(object sender, EventArgs e)
            {
                 ....
            }
        }
    }
