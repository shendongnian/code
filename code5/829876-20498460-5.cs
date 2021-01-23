    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration configuration;
        public CustomControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            this.configuration = configuration;
        }
        public override HttpControllerDescriptor SelectController(
            HttpRequestMessage request)
        {
            var controllerTypes = this.configuration.Services
                .GetHttpControllerTypeResolver().GetControllerTypes(
                    this.configuration.Services.GetAssembliesResolver());
            var matchedTypes = controllerTypes.Where(i => 
                 typeof(IHttpController).IsAssignableFrom(i)).ToList();
            var controllerName = base.GetControllerName(request);
            var matchedController = matchedTypes.FirstOrDefault(i => 
                    i.Name.ToLower() == controllerName.ToLower() + "controller");
            if (matchedController.Namespace == "WebApiTest.Controllers")
            {
                Type decoratorType = typeof(MyHttpControllerDecorator<>);
                Type decoratedType = decoratorType.MakeGenericType(matchedController);
                return new HttpControllerDescriptor(this.configuration, controllerName, decoratedType);
            }
            else
            {
                return new HttpControllerDescriptor(this.configuration, controllerName, matchedController);
            }
        }
    }
