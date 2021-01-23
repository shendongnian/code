    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;
    using System.Web.Http;
    
    namespace Xxx
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                var config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute("DefaultApi", "myservice/{controller}/{id}", new { id = RouteParameter.Optional });
                app.UseNinjectMiddleware(CreateKernel);
                app.UseNinjectWebApi(config);
            }
        }
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<IMyService>().To<MyService>();
            return kernel;
        }
    }
