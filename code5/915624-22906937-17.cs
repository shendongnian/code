    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.RegisterPerWebRequest<IDbConnection>(() =>
                new Ajx.Dal.DapperConnection().getConnection());
            container.Register<IOrdersRepository, OrdersRepository>();
            container.Register<IOrdersService, OrdersService>();
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
