    using Microsoft.Owin;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using MyProject.Web.API.Factories;
    
    [assembly: OwinStartup(typeof(MyProject.Web.API.Startup))]
    namespace MyProject.Web.API
    {
    	public class Startup
    	{
    		public void Configuration(IAppBuilder app)
    		{
    			RouteConfig.RegisterRoutes(RouteTable.Routes);
    
    			var webApiConfiguration = new HttpConfiguration();
    
    			webApiConfiguration.Routes.MapHttpRoute(
    				name: "DefaultApi",
    				routeTemplate: "api/{controller}/{id}",
    				defaults: new { id = RouteParameter.Optional }
    			);
    
    			webApiConfiguration.Routes.MapHttpRoute(
    				name: "ProductionOrderActionApi",
    				routeTemplate: "api/ProductionOrders/{orderNumber}/{action}",
    				defaults: new { controller = "ProductionOrders" });
    
    			app.UseNinjectMiddleware(CreateKernel);
    			app.UseNinjectWebApi(webApiConfiguration);
    		}
    
    		private static StandardKernel CreateKernel()
    		{
    			var kernel = new StandardKernel();
    			kernel.Load(Assembly.GetExecutingAssembly());
    
    			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
    			RegisterServices(kernel);
    			
    			return kernel;
    		}
    
    		private static void RegisterServices(IKernel kernel)
    		{
    			var containerConfigurator = new NinjectConfigurator();
    			containerConfigurator.Configure(kernel);
    		}
    	}
    }
