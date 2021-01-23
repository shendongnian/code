    public class Startup
    {
        public void Configuration(IAppBuilder builder)
        {
            var config = new HttpConfiguration();
            config.CustomMapODataServiceRoute(routeName: "functions route", routePrefix: "functions",
                model: FunctionStartup.GetEdmModel(),
                controllers: new[] { typeof(ProductsController) });
            config.CustomMapODataServiceRoute(routeName: "actions route", routePrefix: "actions",
                model: ActionStartup.GetEdmModel(),
                controllers: new[] { typeof(MoviesController) });
            config.EnsureInitialized();
            builder.UseWebApi(config);
        }
    }
    public class CustomAttributeRoutingConvention : AttributeRoutingConvention
    {
        private readonly List<Type> _controllers = new List<Type> { typeof(MetadataController) };
        public CustomAttributeRoutingConvention(IEdmModel model, HttpConfiguration configuration, IEnumerable<Type> controllers)
            : base(model, configuration)
        {
            _controllers.AddRange(controllers);
        }
        public override bool ShouldMapController(HttpControllerDescriptor controller)
        {
            return _controllers.Contains(controller.ControllerType);
        }
    }
    public static class HttpConfigExt
    {
        public static ODataRoute CustomMapODataServiceRoute(this HttpConfiguration configuration, string routeName,
            string routePrefix, IEdmModel model, IEnumerable<Type> controllers)
        {
            var routingConventions = ODataRoutingConventions.CreateDefault();
            routingConventions.Insert(0, new CustomAttributeRoutingConvention(model, configuration, controllers));
            return configuration.MapODataServiceRoute(routeName, routePrefix, model, new DefaultODataPathHandler(),
                routingConventions);
        }
    }
